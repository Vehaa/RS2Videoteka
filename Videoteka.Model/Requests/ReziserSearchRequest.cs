using System;
using System.Collections.Generic;
using System.Text;

namespace Videoteka.Model.Requests
{
    public class ReziserSearchRequest
    {
        public int ReziserId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
    }
}
