using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Videoteka.Model.Requests
{
    public class ReziserUpsertRequest
    {
        public int ReziserId { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]

        public string Ime { get; set; }
        [Required(ErrorMessage = "{0} je obavezno polje")]

        public string Prezime { get; set; }
        [Required(ErrorMessage = "{0} je obavezno polje")]

        public DateTime DatumRodjenja { get; set; }
    }
}
