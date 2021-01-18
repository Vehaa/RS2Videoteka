using System;
using System.Collections.Generic;

namespace Videoteka.WebAPI.Database
{
    public partial class Drzava
    {
        public Drzava()
        {
            Film = new HashSet<Film>();
        }

        public int DrzavaId { get; set; }
        public string Naziv { get; set; }

        public ICollection<Film> Film { get; set; }
    }
}
