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
        public int Doelgroep { get; set; }
        public int VlaamseOndPremie { get; set; }
        public int AantalMaandenIBO { get; set; }
        public double TotaleProductiviteitsPremie { get; set; }

        public KVraag1_0()
        {
            Functie = "";
            AantalUrenPerWeek = 0;
            BrutoMaandloonFulltime = 0;
            Doelgroep = 0;
            VlaamseOndPremie = 0;
            AantalMaandenIBO = 0;
            TotaleProductiviteitsPremie = 0;
        }
        public KVraag1_0(Kosten kosten)
        {
            Kosten = kosten;
            Functie = "";
            AantalUrenPerWeek = 0;
            BrutoMaandloonFulltime = 0;
            Doelgroep = 0;
            VlaamseOndPremie = 0;
            AantalMaandenIBO = 0;
            TotaleProductiviteitsPremie = 0;
        }
    }
}
