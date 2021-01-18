using System;
using System.Collections.Generic;
using System.Text;

namespace Videoteka.Model.Models
{
    public class Reziser
    {
        public int ReziserId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }

        public string _imePrezime { get { return Ime + " " + Prezime; } }

    }
}
