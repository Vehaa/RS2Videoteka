using System;
using System.Collections.Generic;
using System.Text;

namespace Videoteka.Model.Models
{
    public class RezervacijaFilma
    {
        public int RezervacijaFilmaId { get; set; }
        public int RacunId { get; set; }
        public int FilmId { get; set; }
        public int KlijentId { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public string Opis { get; set; }
        public DateTime RezervacijaOd { get; set; }
        public DateTime RezervacijaDo { get; set; }
        public bool? Otkazana { get; set; }
        public double Popust { get; set; }
        public decimal? IznosSaPopustom { get; set; }
        public decimal Iznos { get; set; }
        public decimal CijenaIznajmljivanja { get; set; }


        public bool IsOcjenjena { get; set; }
        public float Ocjena { get; set; }
        public string Klijent { get; set; }
        public string RezervacijaInformacije { get; set; }
        public string FilmInformacije { get; set; }
        public string RezervacijaOdDo { get; set; }
        public string RezervacijaBrojDana { get; set; }
        public byte[] SlikaThumb { get; set; }


    }
}
