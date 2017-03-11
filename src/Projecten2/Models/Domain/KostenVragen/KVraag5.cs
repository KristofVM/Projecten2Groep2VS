using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain.KostenVragen
{
    public class KVraag5
    {
        public int Id { get; set; }
        private Kosten Kosten { get; set; }
        public string Type { get; set; }
        public double Bedrag { get; set; }

        public KVraag5(Kosten kosten)
        {
            Kosten = kosten;
            Type = "";
            Bedrag = 0;
        }
    }
}
