using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Videoteka.Model.Models;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Services;

namespace Videoteka.WebAPI.Controllers
{
    public class RacunController : BaseCRUDController<Model.Models.Racun, Model.Requests.RacunSearchRequest, Model.Requests.RacunUpsertRequest, Model.Requests.RacunUpsertRequest>
    {
        public RacunController(ICRUDService<Racun, RacunSearchRequest, RacunUpsertRequest, RacunUpsertRequest> service) : base(service)
        {
        }
    }
}
