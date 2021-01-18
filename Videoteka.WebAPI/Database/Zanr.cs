using System;
using System.Collections.Generic;

namespace Videoteka.WebAPI.Database
{
    public partial class Zanr
    {
        public Zanr()
        {
            Film = new HashSet<Film>();
        }

        public int ZanrId { get; set; }
        public string Naziv { get; set; }

        public ICollection<Film> Film { get; set; }
    }
}
