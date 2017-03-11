using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain.KostenVragen
{
    public class KVraag1_0
    {
        public int Id { get; set; }
        public Kosten Kosten { get; set; }
        public string Functie { get; set; }
        public int AantalUrenPerWeek { get; set; }
        public int BrutoMaandloonFulltime { get; set; }
        //public Doelgroep Doelgroep { get; set; }
        //public VlaamseOndPremie VlaamseOndPremie { get; set; }
        public int AantalMaandenIBO { get; set; }
        public double TotaleProductiviteitsPremie { get; set; }
    }
}
