using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videoteka.WebAPI.Database;

namespace Videoteka.WebAPI.Services
{
    public class RacunService : BaseCRUDService<Model.Models.Racun, Model.Requests.RacunSearchRequest, Database.Racun, Model.Requests.RacunUpsertRequest, Model.Requests.RacunUpsertRequest>
    {
        public RacunService(VideotekaContext context, IMapper mapper) : base(context, mapper)
        {
        }


    }
}
