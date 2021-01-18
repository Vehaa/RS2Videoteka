using System;
using System.Collections.Generic;
using System.Text;

namespace Videoteka.Model.Models
{
    public class Ocjena
    {
        public int OcjenaId { get; set; }
        public int RezervacijaFilmaId { get; set; }
        public int FilmId { get; set; }
        public int KlijentId { get; set; }
        public DateTime DatumEvidentiranja { get; set; }
        public int Ocjena1 { get; set; }
        public string Napomena { get; set; }

    }
}
