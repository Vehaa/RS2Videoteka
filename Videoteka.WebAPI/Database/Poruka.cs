using System;
using System.Collections.Generic;

namespace Videoteka.WebAPI.Database
{
    public partial class Poruka
    {
        public int PorukaId { get; set; }
        public int RezervacijaFilmaId { get; set; }
        public int KlijentId { get; set; }
        public int UposlenikId { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public bool Procitano { get; set; }
        public string Posiljaoc { get; set; }

        public Klijent Klijent { get; set; }
        public RezervacijaFilma RezervacijaFilma { get; set; }
        public Korisnici Uposlenik { get; set; }
    }
}
