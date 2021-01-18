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
    public class GradController : BaseCRUDController<Model.Models.Grad, Model.Requests.GradSearchRequest, Model.Requests.GradUpsertRequest, Model.Requests.GradUpsertRequest>
    {
        public GradController(ICRUDService<Grad, GradSearchRequest, GradUpsertRequest, GradUpsertRequest> service) : base(service)
        {
        }
    }
}
