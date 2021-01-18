using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videoteka.WebAPI.ML
{
    public class MovieEntry
    {
        [KeyType(count:2000)]
        public int MovieID { get; set; }

        [KeyType(count: 2000)]
        public int CoPurchaseMovieID { get; set; }
    }

    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }

}
