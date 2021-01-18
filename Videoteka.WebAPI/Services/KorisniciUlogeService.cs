using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Controllers;
using Videoteka.WebAPI.Database;

namespace Videoteka.WebAPI.Services
{
    public class KorisniciUlogeService : BaseService<Model.Models.KorisniciUloge, KorisniciUlogeSearchRequest, Database.KorisniciUloge>
    {
        public KorisniciUlogeService(VideotekaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Models.KorisniciUloge> Get(KorisniciUlogeSearchRequest search)
        {
            var query = _context.Set<Database.KorisniciUloge>().AsQueryable();


            if (search.KorisnikId > 0)
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }
            if (search.UlogaId > 0)
            {
                query = query.Where(x => x.UlogaId == search.UlogaId);
            }

            var list = query.Include(x => x.Uloga).ToList();

            return _mapper.Map<List<Model.Models.KorisniciUloge>>(list);
        }
    }
}
