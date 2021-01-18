using System;
using System.Collections.Generic;
using System.Text;

namespace Videoteka.Model.Requests
{
    public class FilmSearchRequest
    {
        public int FilmId { get; set; }
        public int? ZanrId { get; set; }
        public int? DrzavaId { get; set; }
        public int? ReziserId { get; set; }
        public string Naziv { get; set; }
        public string Glumac { get; set; }
        public int? Godina { get; set; }
        public string Jezik { get; set; }
        public bool Dostupan { get; set; }
    }
}
