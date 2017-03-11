﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain.BatenVragen
{
    public class BVraag3
    {
        private Baten Baten { get; set; }
        public int Uren { get; set; }
        public double BrutoMaandloonFulltime { get; set; }

        public BVraag3(Baten baten)
        {
            Baten = baten;
            Uren = 0;
            BrutoMaandloonFulltime = 0;
        }
    }
}
