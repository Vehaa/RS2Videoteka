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
    public class RezervacijaFilmaController : BaseCRUDController<Model.Models.RezervacijaFilma, Model.Requests.RezervacijaFilmaSearchRequest, Model.Requests.RezervacijaFilmaUpsertRequest,
        Model.Requests.RezervacijaFilmaUpsertRequest>
    {
        public RezervacijaFilmaController(ICRUDService<RezervacijaFilma, RezervacijaFilmaSearchRequest, RezervacijaFilmaUpsertRequest, RezervacijaFilmaUpsertRequest> service) : base(service)
        {
        }
    }
}
