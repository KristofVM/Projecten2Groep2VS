﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain.KostenVragen
{
    public class KVraag3
    {
        public int Id { get; set; }
        private Kosten Kosten { get; set; }
        public string Type { get; set; }
        public double Bedrag { get; set; }

        public KVraag3()
        {
            Type = "";
            Bedrag = 0;
        }
        public KVraag3(Kosten kosten)
        {
            Kosten = kosten;
            Type = "";
            Bedrag = 0;
        }
    }
}
