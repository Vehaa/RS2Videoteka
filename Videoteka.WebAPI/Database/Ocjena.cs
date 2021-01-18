using System;
using System.Collections.Generic;

namespace Videoteka.WebAPI.Database
{
    public partial class Ocjena
    {
        public int OcjenaId { get; set; }
        public int RezervacijaFilmaId { get; set; }
        public DateTime DatumEvidentiranja { get; set; }
        public int Ocjena1 { get; set; }
        public string Napomena { get; set; }

        public RezervacijaFilma RezervacijaFilma { get; set; }
    }
}
