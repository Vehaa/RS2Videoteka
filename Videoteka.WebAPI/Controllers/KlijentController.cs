using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Videoteka.Model.Models;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Services;

namespace Videoteka.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlijentController : ControllerBase
    {
        private readonly IKlijentService _service;
        public KlijentController(IKlijentService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public List<Klijent> Get([FromQuery] KlijentSearchRequest request)
        {
            return _service.Get(request);
        }

        [AllowAnonymous]
        [HttpPost]
        public Klijent Insert(KlijentUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public Model.Models.Klijent Update(int id, [FromBody] KlijentUpsertRequest request)
        {
            return _service.Update(id, request);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public Model.Models.Klijent GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
