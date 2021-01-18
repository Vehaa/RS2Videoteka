using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videoteka.WebAPI.Database
{
    public class Reziser
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }

    }
}
