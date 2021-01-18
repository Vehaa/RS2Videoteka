using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Database;

namespace Videoteka.WebAPI.Services
{
    public class ReziseriService : BaseCRUDService<Model.Models.Reziser, ReziserSearchRequest, Database.Reziser, ReziserUpsertRequest, ReziserUpsertRequest>
    {
        public ReziseriService(VideotekaContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.Models.Reziser> Get(Model.Requests.ReziserSearchRequest search)
        {
            var query = _context.Set<Database.Reziser>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Ime.ToLower().StartsWith(search.Ime));

            }

            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Prezime.ToLower().StartsWith(search.Prezime));

            }

            if (search.ReziserId > 0)
            {
                query = query.Where(x => x.Id == search.ReziserId);
            }


            var list = query.ToList();

            List<Model.Models.Reziser> result = _mapper.Map<List<Model.Models.Reziser>>(list);

            return result;
        }
    }
}
