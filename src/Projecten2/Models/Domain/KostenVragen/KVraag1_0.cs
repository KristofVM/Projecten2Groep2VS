using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("DoelgroepId")]
        public Doelgroep Doelgroep { get; set; }
        public int DoelgroepId { get; set; }
        public int VlaamseOndPremie { get; set; }
        public int AantalMaandenIBO { get; set; }
        public double TotaleProductiviteitsPremie { get; set; }

        public KVraag1_0()
        {
            Functie = "";
            AantalUrenPerWeek = 0;
            BrutoMaandloonFulltime = 0;
            VlaamseOndPremie = 0;
            AantalMaandenIBO = 0;
            TotaleProductiviteitsPremie = 0;
        }

        public double DoelGroepVermindering()
        {
            if ((Doelgroep.DoelgroepValue == 1550 && BrutoMaandloonFulltime < 2500) ||
                (Doelgroep.DoelgroepValue == 1000 && BrutoMaandloonFulltime < 2500) ||
                (Doelgroep.DoelgroepValue == 1150 && BrutoMaandloonFulltime < 4466.66) ||
                (Doelgroep.DoelgroepValue == 1500 && BrutoMaandloonFulltime < 4466.66))
                return (double) Doelgroep.DoelgroepValue / Kosten.Analyse.UrenVoltijdsWerkweek * AantalUrenPerWeek / 4;
            return 0;
        }

        public double BrutoMaandloonIncPatBijd(int UrenVoltijdseWerkweek, int PatronaleBijdrage)
        {
            return (double) BrutoMaandloonFulltime / (double) UrenVoltijdseWerkweek * (double) AantalUrenPerWeek * (1 + (double) PatronaleBijdrage / 100);
        }

        public double GemiddeldeVOP(int UrenVoltijdseWerkweek, int PatronaleBijdrage)
        {
            return (BrutoMaandloonIncPatBijd(UrenVoltijdseWerkweek, PatronaleBijdrage) - DoelGroepVermindering() / 3) * VlaamseOndPremie / 100;
        }

        public double TotaleLoonkostEersteJaar(int UrenVoltijdseWerkweek, int PatronaleBijdrage)
        {
            return (BrutoMaandloonIncPatBijd(UrenVoltijdseWerkweek, PatronaleBijdrage) - GemiddeldeVOP(UrenVoltijdseWerkweek, PatronaleBijdrage) - DoelGroepVermindering()) * (13.92 - AantalMaandenIBO) + TotaleProductiviteitsPremie;
        }
        public KVraag1_0(Kosten kosten, Doelgroep doelgroep)
        {
            Kosten = kosten;
            Functie = "";
            AantalUrenPerWeek = 0;
            BrutoMaandloonFulltime = 0;
            Doelgroep = doelgroep;
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
            VlaamseOndPremie = 0;
            AantalMaandenIBO = 0;
            TotaleProductiviteitsPremie = 0;
        }
    }
}
