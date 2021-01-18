using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Database;

namespace Videoteka.WebAPI.Services
{
    public class KorisniciService : IKorisniciService
    {
        private readonly VideotekaContext _context;
        private readonly IMapper _mapper;

        public KorisniciService(VideotekaContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Models.Korisnici Autentificiraj(string username, string password)
        {
            var user = _context.Korisnici.Include("KorisniciUloge.Uloga").FirstOrDefault(x => x.UserName == username);
            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, password);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Models.Korisnici>(user);
                }
            }
            return null;
        }
        public List<Model.Models.Korisnici> Get(KorisniciSearchRequest request)
        {
            var query = _context.Set<Korisnici>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.ToLower().StartsWith(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.ToLower().StartsWith(request.Prezime));
            }

            if (!string.IsNullOrWhiteSpace(request?.UserName))
            {
                query = query.Where(x => x.UserName.ToLower().StartsWith(request.UserName));
            }

            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(x => x.Email.ToLower() == request.Email.ToLower());

            }
            query = query.Where(x => x.Status == request.Status);

            if (request.GradId > 0)
            {
                query = query.Where(x => x.GradId == request.GradId);
            }

            query = query.OrderBy(x => x.Ime);

            List<Korisnici> korisnici = new List<Korisnici>();
            korisnici = query.ToList();

            List<Model.Models.Korisnici> result = _mapper.Map<List<Model.Models.Korisnici>>(korisnici);

            return result;
        }

        public Model.Models.Korisnici GetById(int id)
        {
            var entity = _context.Korisnici.Find(id);

            return _mapper.Map<Model.Models.Korisnici>(entity);

        }

        public Model.Models.Korisnici Insert(KorisniciUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnici>(request);

            if (request.Password != request.PasswordPotvrda)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Korisnici.Add(entity);
            _context.SaveChanges();

            foreach (var uloga in request.Uloge)
            {
                Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge();
                Database.Uloge u = _context.Uloge.FirstOrDefault(x => x.UlogaId == uloga);
                korisniciUloge.UlogaId = u.UlogaId;
                korisniciUloge.KorisnikId = entity.KorisnikId;
                korisniciUloge.DatumIzmjene = DateTime.Now;
                _context.KorisniciUloge.Add(korisniciUloge);
            }
            _context.SaveChanges();

            return _mapper.Map<Model.Models.Korisnici>(entity);
        }

        public Model.Models.Korisnici Update(int Id, KorisniciUpsertRequest request)
        {
            var entity = _context.Korisnici.Include(x => x.KorisniciUloge).FirstOrDefault(x => x.KorisnikId == Id);
            _context.Korisnici.Attach(entity);
            _context.Korisnici.Update(entity);
            request.KorisnikId = entity.KorisnikId;

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordPotvrda)
                {
                    throw new Exception("Passwordi se ne slažu");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }


            var trenutneUloge = _context.KorisniciUloge.Where(x => x.KorisnikId == entity.KorisnikId);

            foreach (var uloga in trenutneUloge)
            {
                bool postoji = false;
                List<int> sveSelectovane = request.Uloge;
                foreach (var odabrana in sveSelectovane)
                {
                    if (uloga.UlogaId == odabrana)
                        postoji = true;
                }
                if (!postoji)
                {
                    _context.KorisniciUloge.Remove(uloga);
                }

            }


            foreach (var uloga in request.Uloge)
            {
                var u = _context.KorisniciUloge.FirstOrDefault(x => x.UlogaId == uloga && x.KorisnikId == entity.KorisnikId);

                if (u == null)
                {
                    Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge();
                    Database.Uloge ul = _context.Uloge.FirstOrDefault(x => x.UlogaId == uloga);
                    korisniciUloge.UlogaId = ul.UlogaId;
                    korisniciUloge.KorisnikId = entity.KorisnikId;
                    korisniciUloge.DatumIzmjene = DateTime.Now;
                    _context.KorisniciUloge.Add(korisniciUloge);
                }
            }
            _context.SaveChanges();
            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Models.Korisnici>(entity);
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
