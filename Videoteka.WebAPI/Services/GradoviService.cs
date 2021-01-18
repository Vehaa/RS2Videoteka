using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Database;

namespace Videoteka.WebAPI.Services
{
    public class GradoviService:BaseCRUDService<Model.Models.Grad,GradSearchRequest,Database.Grad,GradUpsertRequest,GradUpsertRequest>
    {

        public GradoviService(VideotekaContext context, IMapper mapper) : base(context, mapper)
        {

        }


        public override List<Model.Models.Grad> Get(Model.Requests.GradSearchRequest search)
        {
            var query = _context.Set<Database.Grad>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.ToLower().StartsWith(search.Naziv));

            }

            if (search.DrzavaId > 0)
            {
                query = query.Where(x => x.DrzavaId == search.DrzavaId);
            }

            var list = query.ToList();

            List<Model.Models.Grad> result = _mapper.Map<List<Model.Models.Grad>>(list);

            return result;
        }
    }
}
