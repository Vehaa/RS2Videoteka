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
    public class OcjenaService : BaseCRUDService<Model.Models.Ocjena, OcjenaSearchRequest, Database.Ocjena, OcjenaUpsertRequest, OcjenaUpsertRequest>
    {
        public OcjenaService(VideotekaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Models.Ocjena> Get(OcjenaSearchRequest search)
        {
            var query = _context.Set<Database.Ocjena>().Include(x => x.RezervacijaFilma).AsQueryable();

            if (search.FilmId > 0)
            {
                query = query.Where(x => x.RezervacijaFilma.FilmId == search.FilmId);
            }

            if (search.RezervacijaFilmaId > 0)
            {
                query = query.Where(x => x.RezervacijaFilmaId == search.RezervacijaFilmaId);
            }

            var list = query.OrderBy(x => x.RezervacijaFilma.KlijentId).ToList();

            List<Model.Models.Ocjena> result = _mapper.Map<List<Model.Models.Ocjena>>(list);
            foreach (var item in result)
            {
                var ocjena = _context.Ocjena.Include(y => y.RezervacijaFilma).Where(x => x.OcjenaId == item.OcjenaId).FirstOrDefault();
                item.KlijentId = ocjena.RezervacijaFilma.KlijentId;
                item.FilmId = ocjena.RezervacijaFilma.FilmId;
            }
            return result;
        }
    }
}
