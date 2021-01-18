using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Database;
using Videoteka.WebAPI.ML;

namespace Videoteka.WebAPI.Services
{
    public class FilmService : BaseCRUDService<Model.Models.Film, FilmSearchRequest, Database.Film, FilmUpsertRequest, FilmUpsertRequest>
    {

        public FilmService(VideotekaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Models.Film> Get(Model.Requests.FilmSearchRequest search)
        {
            var query = _context.Set<Database.Film>().AsQueryable();

            if (search.ZanrId > 0)
            {
                query = query.Where(x => x.ZanrId == search.ZanrId);
            }

            if (search.DrzavaId > 0)
            {
                query = query.Where(x => x.DrzavaId == search.DrzavaId);
            }

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().StartsWith(search.Naziv));
            }

            if (!string.IsNullOrWhiteSpace(search?.Glumac))
            {
                query = query.Where(x => x.Glumac.ToLower().StartsWith(search.Glumac));
            }

            if (search.ReziserId>0)
            {
                query = query.Where(x => x.ReziserId==search.ReziserId); 
            }

            if (search.Godina != null)
            {
                query = query.Where(x => x.Godina == search.Godina);
            }

            if (!string.IsNullOrWhiteSpace(search?.Jezik))
            {
                query = query.Where(x => x.Jezik.ToLower().StartsWith(search.Jezik));
            }

            if (search.Dostupan == true)
            {
                query = query.Where(x => x.Dostupan == search.Dostupan);
            }

            if (search.Dostupan == false)
            {
                query = query.Where(x => x.Dostupan == search.Dostupan);
            }

            var list = query.ToList();

            List<Model.Models.Film> result = _mapper.Map<List<Model.Models.Film>>(list);

            return result;

        }

        public override Model.Models.Film GetById(int id)
        {
            var entity = _context.Film.Find(id);

            return _mapper.Map<Model.Models.Film>(entity);
        }

        public  List<Model.Models.Film> Recommend()
        {
            List<Model.Models.Film> filmovi = new List<Model.Models.Film>();

            var ocjene = _context.Ocjena.Include(x => x.RezervacijaFilma).ThenInclude(y => y.Film).ToList();
            var sviFilmovi = _context.Set<Database.Film>().AsQueryable();
            var sveRezervacije = _context.RezervacijaFilma.ToList();

            foreach (var f in sviFilmovi)
            {
                foreach (var r in sveRezervacije)
                {
                    int brojac = 0;
                    double suma = 0;
                    double prosjek = 0;
                    foreach (var o in ocjene)
                    {
                        if(f.FilmId==r.FilmId && o.RezervacijaFilmaId==r.RezervacijaFilmaId)
                        {
                            brojac++;

                            suma += o.Ocjena1;
                        }
                        prosjek = suma / brojac;
                        filmovi.Add(_mapper.Map<Model.Models.Film>(f));
                        foreach (var item in filmovi)
                        {
                            if(item.FilmId==f.FilmId)
                                item.ProsjecnaOcjena = prosjek;
                        }
                    }
                }
            }
            


            var result = filmovi.OrderByDescending(x => x.ProsjecnaOcjena).ToList();

            return result;
        }

    }


}
