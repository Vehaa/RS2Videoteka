using System;
using System.Collections.Generic;
using System.Text;

namespace Videoteka.Model.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public int ZanrId { get; set; }
        public int DrzavaId { get; set; }
        public int ReziserId { get; set; }
        public string Naziv { get; set; }
        public string Glumac { get; set; }
        public string Opis { get; set; }
        public int Godina { get; set; }
        public decimal Trajanje { get; set; }
        public string Jezik { get; set; }
        public bool Dostupan { get; set; }
        public decimal CijenaIznajmljivanja { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }

        public double ProsjecnaOcjena { get; set; }
    }
}
