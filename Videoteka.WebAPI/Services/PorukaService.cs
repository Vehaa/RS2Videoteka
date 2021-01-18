using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Database;

namespace Videoteka.WebAPI.Services
{
    public class PorukaService : BaseCRUDService<Model.Models.Poruka, Model.Requests.PorukaSearchRequest, Database.Poruka, Model.Requests.PorukaUpsertRequest, Model.Requests.PorukaUpsertRequest>
    {
        public PorukaService(VideotekaContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Model.Models.Poruka> Get(PorukaSearchRequest search)
        {
            var query = _context.Set<Database.Poruka>().Include(x => x.Klijent)
                                                       .Include(y => y.Uposlenik)
                                                       .Include(z => z.RezervacijaFilma)
                                                       .OrderByDescending(x => x.DatumVrijeme)
                                                       .AsQueryable();

            if (search.KlijentId > 0)
            {
                query = query.Where(x => x.KlijentId == search.KlijentId);
            }
            if (search.RezervacijaFilmaId > 0)
            {
                query = query.Where(x => x.RezervacijaFilmaId == search.RezervacijaFilmaId);
            }
            if (search.UposlenikId > 0)
            {
                query = query.Where(x => x.UposlenikId == search.UposlenikId);
            }
            if (!string.IsNullOrWhiteSpace(search?.Posiljaoc))
            {
                query = query.Where(x => x.Posiljaoc == search.Posiljaoc);
            }
            if (!string.IsNullOrWhiteSpace(search?.PrimaocIme))
            {
                query = query.Where(x => x.Klijent.Ime.ToLower().StartsWith(search.PrimaocIme));
            }
            if (!string.IsNullOrWhiteSpace(search?.PrimaocPrezime))
            {
                query = query.Where(x => x.Klijent.Prezime.ToLower().StartsWith(search.PrimaocPrezime));
            }
            if (!string.IsNullOrWhiteSpace(search?.PrimaocUsername))
            {
                query = query.Where(x => x.Klijent.UserName.ToLower().StartsWith(search.PrimaocUsername));
            }
            if (!string.IsNullOrWhiteSpace(search?.PosiljaocIme))
            {
                query = query.Where(x => x.Klijent.Ime.ToLower().StartsWith(search.PosiljaocIme));
            }
            if (!string.IsNullOrWhiteSpace(search?.PosiljaocPrezime))
            {
                query = query.Where(x => x.Klijent.Prezime.ToLower().StartsWith(search.PosiljaocPrezime));
            }
            if (!string.IsNullOrWhiteSpace(search?.PosiljaocUsername))
            {
                query = query.Where(x => x.Klijent.UserName.ToLower().StartsWith(search.PosiljaocUsername));
            }
            if (search.DatumVrijemeOd.HasValue)
            {
                query = query.Where(x => x.DatumVrijeme.Date >= search.DatumVrijemeOd.Value.Date);
            }
            if (search.DatumVrijemeDo.HasValue)
            {
                query = query.Where(x => x.DatumVrijeme.Date <= search.DatumVrijemeDo.Value.Date);
            }


            var list = query.ToList();

            List<Model.Models.Poruka> result = _mapper.Map<List<Model.Models.Poruka>>(list);
            foreach (var item in result)
            {
                var uposlenik = _context.Korisnici.FirstOrDefault(x => x.KorisnikId == item.UposlenikId);
                var klijent = _context.Klijent.FirstOrDefault(x => x.KlijentId == item.KlijentId);

                if (item.Posiljaoc == "Klijent")
                {
                    item.PosiljaocInfo = klijent.Ime + " " + klijent.Prezime + " (" + klijent.UserName + ")";
                    item.PrimaocInfo = uposlenik.Ime + " " + uposlenik.Prezime + " (" + uposlenik.UserName + ")";
                    if (klijent.SlikaThumb.Length > 0)
                        item.PosiljaocSlikaThumb = klijent.SlikaThumb;
                }
                else
                {
                    item.PosiljaocInfo = uposlenik.Ime + " " + uposlenik.Prezime + " (" + uposlenik.UserName + ")";
                    item.PrimaocInfo = klijent.Ime + " " + klijent.Prezime + " (" + klijent.UserName + ")";
                    if (uposlenik.SlikaThumb!=null && uposlenik.SlikaThumb.Length > 0)
                        item.PosiljaocSlikaThumb = uposlenik.SlikaThumb;
                }

            }

            return result;
        }

        public override Model.Models.Poruka GetById(int id)
        {
            var poruka = _context.Poruka.FirstOrDefault(x => x.PorukaId == id);
            var uposlenik = _context.Korisnici.FirstOrDefault(x => x.KorisnikId == poruka.UposlenikId);
            var klijent = _context.Klijent.FirstOrDefault(x => x.KlijentId == poruka.KlijentId);


            var result = _mapper.Map<Model.Models.Poruka>(poruka);
            if (result.Posiljaoc == "Klijent")
            {
                result.PosiljaocInfo = klijent.Ime + " " + klijent.Prezime + " (" + klijent.UserName + ")";
                result.PrimaocInfo = uposlenik.Ime + " " + uposlenik.Prezime + " (" + uposlenik.UserName + ")";
                if (klijent.SlikaThumb.Length > 0)
                    result.PosiljaocSlikaThumb = klijent.SlikaThumb;
            }
            else
            {
                result.PosiljaocInfo = uposlenik.Ime + " " + uposlenik.Prezime + " (" + uposlenik.UserName + ")";
                result.PrimaocInfo = klijent.Ime + " " + klijent.Prezime + " (" + klijent.UserName + ")";
                if (uposlenik.SlikaThumb != null && uposlenik.SlikaThumb.Length > 0)
                    result.PosiljaocSlikaThumb = uposlenik.SlikaThumb;
            }


            return result;
        }

    }
}
