using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Videoteka.Model.Requests
{
    public class ZanrUpsertRequest
    {
        public int ZanrId { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]
        public string Naziv { get; set; }
    }
}
