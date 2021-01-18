using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Database;

namespace Videoteka.WebAPI.Services
{
    public class ZanrService : BaseCRUDService<Model.Models.Zanr,ZanrSearchRequest, Database.Zanr, ZanrUpsertRequest, ZanrUpsertRequest>
    {
        public ZanrService(VideotekaContext context, IMapper mapper) : base(context, mapper)
        {

        }


        public override List<Model.Models.Zanr> Get(Model.Requests.ZanrSearchRequest search)
        {
            var query = _context.Set<Database.Zanr>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().StartsWith(search.Naziv));

            }


            var list = query.ToList();

            List<Model.Models.Zanr> result = _mapper.Map<List<Model.Models.Zanr>>(list);

            return result;
        }

    }
}
