using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain.KostenVragen
{
    public class KVraag1_1
    {
        private Kosten Kosten { get; set; }
        public string Beschrijving { get; set; }
        public double JaarBedrag { get; set; }

        public KVraag1_1(Kosten kosten)
        {
            Kosten = kosten;
            Beschrijving = "";
            JaarBedrag = 0;
        }
    }
}
