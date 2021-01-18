using System;
using System.Collections.Generic;
using System.Text;

namespace Videoteka.Model.Models
{
    public class Racun
    {
        public int RacunId { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public decimal UkupanIznos { get; set; }

        public ICollection<RezervacijaFilma> RezervacijaFilma { get; set; }
    }
}
