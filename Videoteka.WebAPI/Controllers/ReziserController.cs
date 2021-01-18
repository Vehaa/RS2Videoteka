using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Videoteka.Model.Models;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Services;

namespace Videoteka.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReziserController : BaseCRUDController<Model.Models.Reziser, Model.Requests.ReziserSearchRequest, Model.Requests.ReziserUpsertRequest, Model.Requests.ReziserUpsertRequest>
    {
        public ReziserController(ICRUDService<Reziser, ReziserSearchRequest, ReziserUpsertRequest, ReziserUpsertRequest> service) : base(service)
        {
        }
    }
}
