using System;
using System.Collections.Generic;
using System.Text;

namespace Videoteka.Model.Requests
{
    public class OcjenaSearchRequest
    {
        public int OcjenaId { get; set; }
        public int FilmId { get; set; }
        public int RezervacijaFilmaId { get; set; }

    }
}
