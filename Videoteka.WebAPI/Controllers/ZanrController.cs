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
    public class ZanrController : BaseCRUDController<Model.Models.Zanr, Model.Requests.ZanrSearchRequest, Model.Requests.ZanrUpsertRequest, Model.Requests.ZanrUpsertRequest>
    {
        public ZanrController(ICRUDService<Zanr, ZanrSearchRequest, ZanrUpsertRequest, ZanrUpsertRequest> service) : base(service)
        {
        }
    }
}
