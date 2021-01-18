using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Videoteka.Model.Models;
using Videoteka.WebAPI.Services;

namespace Videoteka.WebAPI.Controllers
{
    public class UlogaController : BaseController<Model.Models.Uloge, object>
    {
        public UlogaController(IService<Uloge, object> service) : base(service)
        {
        }
    }
}
