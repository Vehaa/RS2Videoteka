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
    public class RezervacijaFilmovaService : BaseCRUDService<Model.Models.RezervacijaFilma,Model.Requests.RezervacijaFilmaSearchRequest,Database.RezervacijaFilma,
        Model.Requests.RezervacijaFilmaUpsertRequest,Model.Requests.RezervacijaFilmaUpsertRequest>
    {
        public RezervacijaFilmovaService(VideotekaContext context,IMapper mapper) : base(context,mapper)
        {
        }

        public override List<Model.Models.RezervacijaFilma> Get(RezervacijaFilmaSearchRequest search)
        {
            var query = _context.Set<Database.RezervacijaFilma>().Include(x => x.Film)
                                                                    .ThenInclude(y => y.Zanr)
                                                                    .Include(f => f.Klijent)
                                                                    .OrderByDescending(x => x.RezervacijaOd)
                                                                    .AsQueryable();

            #region Search
            if (search.FilmId > 0)
            {
                query = query.Where(x => x.FilmId == search.FilmId);
            }
            if (search.KlijentId > 0)
            {
                query = query.Where(x => x.KlijentId == search.KlijentId);
            }
       
            if (!string.IsNullOrWhiteSpace(search.Ime))
            {
                var klijent = _context.Klijent.Where(y => y.Ime.StartsWith(search.Ime)).FirstOrDefault();
                if (klijent != null)
                {
                    query = query.Where(x => x.Klijent.Ime.StartsWith(search.Ime));

                }
            }
            if (!string.IsNullOrWhiteSpace(search.Prezime))
            {
                var klijent = _context.Klijent.Where(y => y.Prezime.StartsWith(search.Prezime)).FirstOrDefault();
                if (klijent != null)
                {
                    query = query.Where(x => x.Klijent.Prezime.StartsWith(search.Prezime));
                }
            }
            if (!string.IsNullOrWhiteSpace(search.Username))
            {
                var klijent = _context.Klijent.Where(y => y.UserName.StartsWith(search.Username)).FirstOrDefault();
                if (klijent != null)
                {
                    query = query.Where(x => x.Klijent.UserName.StartsWith(search.Username));

                }
            }
           
            if (search.RezervacijaOd.HasValue)
            {
                query = query.Where(x => x.RezervacijaOd >= search.RezervacijaOd.Value.Date);
            }
            if (search.RezervacijaDo.HasValue)
            {
                query = query.Where(x => x.RezervacijaDo <= search.RezervacijaDo.Value.Date);
            }
            if (search.DatumKreiranja.HasValue)
            {
                query = query.Where(x => x.DatumKreiranja == search.DatumKreiranja.Value.Date);
            }
            if (search.StatusAktivna == true)
            {
                var max = DateTime.MaxValue;
                query = query.Where(x => x.RezervacijaDo>=DateTime.Now.Date);

            }

            if (search.StatusAktivna == false)
            {
                query = query.Where(x => x.RezervacijaDo < DateTime.Now.Date ||x.Otkazana==true);

            }
            if (search.Otkazana == true && search.StatusAktivna==false)
            {
                query = query.Where(x => (bool)x.Otkazana ==(bool) search.Otkazana);

            }

            if (search.Otkazana == false)
            {
                query = query.Where(x => x.Otkazana == search.Otkazana);

            }


            #endregion

            var list = query.ToList();

            #region ModelPLUS attributes
            List<Model.Models.RezervacijaFilma> result = _mapper.Map<List<Model.Models.RezervacijaFilma>>(list);
            foreach (var item in result)
            {
                var film = _context.Film.Include(y => y.Zanr)
                                               .FirstOrDefault(x => x.FilmId == item.FilmId);

                item.FilmInformacije = film.Naziv + " (" + film.Godina + ") ";
                item.RezervacijaInformacije = item.DatumKreiranja.ToShortDateString() + " (" + item.FilmInformacije + ")";
                var klijent = _context.Klijent.FirstOrDefault(x => x.KlijentId == item.KlijentId);
                item.Klijent = klijent.Ime + " " + klijent.Prezime;

                

                if (film.Slika != null)
                    item.SlikaThumb = film.Slika;

                item.CijenaIznajmljivanja = film.CijenaIznajmljivanja;
                item.RezervacijaOdDo = item.RezervacijaOd.ToShortDateString() + " - " + item.RezervacijaDo.ToShortDateString();
                item.RezervacijaBrojDana = (item.RezervacijaDo - item.RezervacijaOd).Days.ToString();
                if (item.RezervacijaBrojDana == "0")
                    item.RezervacijaBrojDana = "1";
                Database.Ocjena ocjene = _context.Ocjena.FirstOrDefault(x => x.RezervacijaFilmaId == item.RezervacijaFilmaId);
                if (ocjene != null)
                {
                    item.IsOcjenjena = true;
                    item.Ocjena = ocjene.Ocjena1;
                }
                else
                    item.IsOcjenjena = false;

                
            }
            #endregion 

            return result;
        }

        public override Model.Models.RezervacijaFilma GetById(int id)
        {
            var rezervacija = _context.RezervacijaFilma.FirstOrDefault(x => x.RezervacijaFilmaId == id);
            var klijent = _context.Klijent.FirstOrDefault(x => x.KlijentId == rezervacija.KlijentId);
            var film = _context.Film.Include(y => y.Zanr).FirstOrDefault(x => x.FilmId == rezervacija.FilmId);

            var result = _mapper.Map<Model.Models.RezervacijaFilma>(rezervacija);
            result.FilmInformacije = film.Naziv + " (" + film.Godina+") ";
            result.RezervacijaInformacije = result.DatumKreiranja.ToShortDateString() + " (" + result.FilmInformacije + ")";
            result.Klijent = klijent.Ime + " " + klijent.Prezime;



            if (film.Slika != null)
                result.SlikaThumb = film.Slika;

            result.CijenaIznajmljivanja = film.CijenaIznajmljivanja;
            result.RezervacijaOdDo = result.RezervacijaOd.ToString() + " - " + result.RezervacijaDo.ToString();
            result.RezervacijaBrojDana = (result.RezervacijaDo - result.RezervacijaOd).Days.ToString();
            if (result.RezervacijaBrojDana == "0")
                result.RezervacijaBrojDana = "1";

            Database.Ocjena ocjene = _context.Ocjena.FirstOrDefault(x => x.RezervacijaFilmaId == result.RezervacijaFilmaId);
            if (ocjene != null)
            {
                result.IsOcjenjena = true;
                result.Ocjena = ocjene.Ocjena1;
            }
            else
                result.IsOcjenjena = false;
            
            return result;
        }

    }
}
