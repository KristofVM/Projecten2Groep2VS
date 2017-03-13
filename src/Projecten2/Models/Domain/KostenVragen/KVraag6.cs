using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain.KostenVragen
{
    public class KVraag6
    {
        public int Id { get; set; }
        private Kosten Kosten { get; set; }
        public int Uren { get; set; }
        public double BrutoMaandloonBegeleider { get; set; }

        public KVraag6(Kosten kosten)
        {
            Kosten = kosten;
            Uren = 0;
            BrutoMaandloonBegeleider = 0;
        }
    }
}
