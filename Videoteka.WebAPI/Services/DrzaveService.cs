using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Database;

namespace Videoteka.WebAPI.Services
{
    public class DrzaveService: BaseCRUDService<Model.Models.Drzava, DrzavaSearchRequest, Database.Drzava, DrzavaUpsertRequest, DrzavaUpsertRequest>
    {
        public DrzaveService(VideotekaContext context, IMapper mapper) : base(context, mapper)
        {

        }


        public override List<Model.Models.Drzava> Get(Model.Requests.DrzavaSearchRequest search)
        {
            var query = _context.Set<Database.Drzava>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().StartsWith(search.Naziv));

            }


            var list = query.ToList();

            List<Model.Models.Drzava> result = _mapper.Map<List<Model.Models.Drzava>>(list);

            return result;
        }


    }
}
