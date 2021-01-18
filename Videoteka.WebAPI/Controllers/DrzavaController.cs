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
    [Route("api/[controller]")]
    [ApiController]
    public class DrzavaController : BaseCRUDController<Model.Models.Drzava, Model.Requests.DrzavaSearchRequest, Model.Requests.DrzavaUpsertRequest, Model.Requests.DrzavaUpsertRequest>
    {
        public DrzavaController(ICRUDService<Drzava, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest> service) : base(service)
        {
        }
    }
}
