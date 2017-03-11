using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain.BatenVragen
{
    public class BVraag11
    {
        private Baten Baten { get; set; }
        public string TypeBesparing { get; set; }
        public double JaarBedrag { get; set; }

        public BVraag11(Baten baten)
        {
            Baten = baten;
            TypeBesparing = "";
            JaarBedrag = 0;
        }
    }
}
