using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Videoteka.Model.Requests;

namespace Videoteka.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnici, Model.Models.Korisnici>();
            CreateMap<Database.Korisnici, KorisniciUpsertRequest>().ReverseMap();
            CreateMap<Database.KorisniciUloge, Model.Models.KorisniciUloge>();
            CreateMap<Database.KorisniciUloge, KorisniciUpsertRequest>();
            CreateMap<Database.Klijent, KlijentUpsertRequest>().ReverseMap();
            CreateMap<Database.Klijent, Model.Models.Klijent>().ReverseMap();
            CreateMap<Database.Film, Model.Models.Film>();
            CreateMap<Database.Film, FilmUpsertRequest>().ReverseMap();
            CreateMap<Database.Drzava, Model.Requests.DrzavaUpsertRequest>().ReverseMap();
            CreateMap<Database.Drzava, Model.Models.Drzava>().ReverseMap();
            CreateMap<Database.Grad, Model.Requests.GradUpsertRequest>().ReverseMap();
            CreateMap<Database.Grad, Model.Models.Grad>().ReverseMap();
            CreateMap<Database.Zanr, Model.Requests.ZanrUpsertRequest>().ReverseMap();
            CreateMap<Database.Zanr, Model.Models.Zanr>().ReverseMap();
            CreateMap<Database.Reziser, Model.Requests.ReziserUpsertRequest>().ReverseMap();
            CreateMap<Database.Reziser, Model.Models.Reziser>().ReverseMap();
            CreateMap<Database.RezervacijaFilma, Model.Requests.RezervacijaFilmaUpsertRequest>().ReverseMap();
            CreateMap<Database.RezervacijaFilma, Model.Models.RezervacijaFilma>().ReverseMap();
            CreateMap<Database.Poruka, Model.Requests.PorukaUpsertRequest>().ReverseMap();
            CreateMap<Database.Poruka, Model.Models.Poruka>().ReverseMap();
            CreateMap<Database.Racun, Model.Requests.RacunUpsertRequest>().ReverseMap();
            CreateMap<Database.Ocjena, Model.Models.Ocjena>().ReverseMap();
            CreateMap<Database.Ocjena, Model.Requests.OcjenaUpsertRequest>().ReverseMap();


        }
    }
}
