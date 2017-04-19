using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain.KostenVragen
{
    public class KVraag4
    {
        public int Id { get; set; }
        private Kosten Kosten { get; set; }
        public string Type { get; set; }
        public double Bedrag { get; set; }

        public KVraag4()
        {
            Type = "";
            Bedrag = 0;
        }
        public KVraag4(Kosten kosten)
        {
            Kosten = kosten;
            Type = "";
            Bedrag = 0;
        }
    }
}
