using System;
using System.Collections.Generic;

namespace Videoteka.WebAPI.Database
{
    public partial class Grad
    {
        public Grad()
        {
            Klijent = new HashSet<Klijent>();
            Korisnici = new HashSet<Korisnici>();
        }

        public int GradId { get; set; }
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }

        public ICollection<Klijent> Klijent { get; set; }
        public ICollection<Korisnici> Korisnici { get; set; }
    }
}
