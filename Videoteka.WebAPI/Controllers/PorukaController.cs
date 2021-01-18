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
    public class PorukaController : BaseCRUDController<Model.Models.Poruka, Model.Requests.PorukaSearchRequest, Model.Requests.PorukaUpsertRequest, Model.Requests.PorukaUpsertRequest>
    {
        public PorukaController(ICRUDService<Poruka, PorukaSearchRequest, PorukaUpsertRequest, PorukaUpsertRequest> service) : base(service)
        {
        }
    }
}
