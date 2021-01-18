using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Database;
using Videoteka.WebAPI.Services;

namespace Videoteka.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _service;
        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }
        [HttpGet]
        public  List<Model.Models.Korisnici> Get([FromQuery]KorisniciSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{id}")]
        public Model.Models.Korisnici GetById(int id)
        {
            return _service.GetById(id);
        }



        [HttpPost]
        public Model.Models.Korisnici Insert(KorisniciUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Model.Models.Korisnici Update(int id, [FromBody] KorisniciUpsertRequest request)
        {
            var r = _service.Update(id, request);

            return r;
        }
    }
}
