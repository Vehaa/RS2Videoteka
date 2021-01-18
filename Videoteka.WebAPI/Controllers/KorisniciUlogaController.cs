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
    public class KorisniciUlogaController : BaseController<Model.Models.KorisniciUloge, KorisniciUlogeSearchRequest>
    {
        public KorisniciUlogaController(IService<KorisniciUloge, KorisniciUlogeSearchRequest> service) : base(service)
        {
        }
    }
}
