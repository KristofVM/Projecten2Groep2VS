using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain.BatenVragen
{
    public class BVraag5
    {
        private Baten Baten { get; set; }
        public string Beschrijving { get; set; }
        public double JaarBedrag { get; set; }

        public BVraag5(Baten baten)
        {
            Baten = baten;
            Beschrijving = "";
            JaarBedrag = 0;
        }
    }
}
