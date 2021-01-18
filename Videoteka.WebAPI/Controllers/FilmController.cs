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
    public class FilmController : BaseCRUDController<Model.Models.Film, FilmSearchRequest, FilmUpsertRequest, FilmUpsertRequest>
    {
        public FilmController(ICRUDService<Film, FilmSearchRequest, FilmUpsertRequest, FilmUpsertRequest> service) : base(service)
        {
        }


    }
}
