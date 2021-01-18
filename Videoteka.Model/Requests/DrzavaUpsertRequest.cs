using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Videoteka.Model.Requests
{
    public class DrzavaUpsertRequest
    {
        public int DrzavaId { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]
        public string Naziv { get; set; }
    }
}
