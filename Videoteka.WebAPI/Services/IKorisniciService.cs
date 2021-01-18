using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videoteka.Model.Requests;
using Videoteka.WebAPI.Database;

namespace Videoteka.WebAPI.Services
{
    public interface IKorisniciService
    {
        List<Model.Models.Korisnici> Get(KorisniciSearchRequest request);
        Model.Models.Korisnici GetById(int id);
        Model.Models.Korisnici Insert(KorisniciUpsertRequest request);
        Model.Models.Korisnici Update(int Id, KorisniciUpsertRequest request);
        Model.Models.Korisnici Autentificiraj(string username, string password);
    }
}
