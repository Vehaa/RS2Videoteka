using System;
using System.Collections.Generic;

namespace Videoteka.WebAPI.Database
{
    public partial class Racun
    {
        public Racun()
        {
            RezervacijaFilma = new HashSet<RezervacijaFilma>();
        }

        public int RacunId { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public decimal UkupanIznos { get; set; }

        public ICollection<RezervacijaFilma> RezervacijaFilma { get; set; }
    }
}
