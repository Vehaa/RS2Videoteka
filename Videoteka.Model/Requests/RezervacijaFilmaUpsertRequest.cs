using System;
using System.Collections.Generic;
using System.Text;

namespace Videoteka.Model.Requests
{
    public class RezervacijaFilmaUpsertRequest
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
    }
}
