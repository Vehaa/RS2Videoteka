using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Videoteka.Model.Requests
{
    public class FilmUpsertRequest
    {
        public int FilmId { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]
        public int ZanrId { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]
        public int DrzavaId { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]
        [MaxLength(50, ErrorMessage = "Polje {0} ne smije biti duže od {1} karaktra")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]
        [MaxLength(50, ErrorMessage = "Polje {0} ne smije biti duže od {1} karaktra")]
        public string Glumac { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]
        public int ReziserId { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]
        [MaxLength(5000, ErrorMessage = "Polje {0} ne smije biti duže od {1} karaktra")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]
        public int Godina { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]
        public decimal Trajanje { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]
        [MaxLength(50, ErrorMessage = "Polje {0} ne smije biti duže od {1} karaktra")]
        public string Jezik { get; set; }
        public bool Dostupan { get; set; }

        [Required(ErrorMessage = "{0} je obavezno polje")]
        public decimal CijenaIznajmljivanja { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
    }
}
