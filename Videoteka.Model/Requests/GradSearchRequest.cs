using System;
using System.Collections.Generic;
using System.Text;

namespace Videoteka.Model.Requests
{
    public class GradSearchRequest
    {
        public int GradId { get; set; }
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }

    }
}
