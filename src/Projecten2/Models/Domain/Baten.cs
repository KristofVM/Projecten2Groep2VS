using System;
using System.Collections.Generic;
using System.Linq;
using Projecten2.Models.Domain.BatenVragen;

namespace Projecten2.Models.Domain
{
    public class Baten
    {
        public int BatenId { get; set; }
        public Analyse Analyse { get; set; }

        public double JaarBedSubsWerkOmg { get; set; } //Vraag 2
        public double JaarBedOmzetVerlies { get; set; } //Vraag 6
        public int ProcentBesparing { get; set; } //Vraag 6
        public double JaarBedExtraProd { get; set; } //Vraag 7
        public double JaarBedOveruren { get; set; } //Vraag 8
        public double JaarBedTransportKost { get; set; } //Vraag 10.1
        public double JaarBedHandelingsKost { get; set; } //Vraag 10.2

        public ICollection<BVraag3> Bvragen3 { get; set; }
        public ICollection<BVraag4> Bvragen4 { get; set; }
        public ICollection<BVraag5> Bvragen5 { get; set; }
        public ICollection<BVraag9> Bvragen9 { get; set; }
        public ICollection<BVraag11> Bvragen11 { get; set; }

        public double subtotaal()
        {
            double totaal = 0;
            for (int i = 1; i <= 11; i++)
            {
                totaal = totaal + getTotaalBVragen(i);
            }
            return totaal;
        }
        public double getTotaalBVragen(int vraag)
        {
            if (vraag == 1)
            {
                double deel1 = Analyse.Kosten.GetTotaalKVragen(1);
            }
            if (vraag == 2)
            {
                return JaarBedSubsWerkOmg;
            }
            if (vraag == 3)
            {
                if (Bvragen3.Count == 0)
                    return 0;
                return Bvragen3.Sum(a => a.Uren / (double)Analyse.PatronaleBijdrage / 100* a.BrutoMaandloonFulltime * (1+ (double)Analyse.PatronaleBijdrage/100)*13.92);
            }
            if (vraag == 4)
            {
                if (Bvragen4.Count == 0)
                    return 0;
                return Bvragen3.Sum(a => a.Uren / (double)Analyse.PatronaleBijdrage / 100 * a.BrutoMaandloonFulltime * (1 + (double)Analyse.PatronaleBijdrage / 100) * 13.92);
            }
            if (vraag == 5)
            {
                if (Bvragen5.Count == 0)
                    return 0;
                return Bvragen5.Sum(a => a.JaarBedrag);
            }
            if (vraag == 6)
            {
                return JaarBedOmzetVerlies * ProcentBesparing / 100;
            }
            if (vraag == 7)
            {
                return JaarBedExtraProd;
            }
            if (vraag == 8)
            {
                return JaarBedOveruren;
            }
            if (vraag == 9)
            {
                if (Bvragen9.Count == 0)
                    return 0;
                return Bvragen9.Sum(a => a.JaarBedrag);
            }
            if (vraag == 10)
            {
                return JaarBedTransportKost + JaarBedHandelingsKost;
            }
            if (vraag == 11)
            {
                if (Bvragen11.Count == 0)
                    return 0;
                return Bvragen11.Sum(a => a.JaarBedrag);
            }
            return 0;
        }
        public Baten()
        {
            JaarBedOmzetVerlies = 0;
            JaarBedOmzetVerlies = 0;
            ProcentBesparing = 0;
            JaarBedExtraProd = 0;
            JaarBedOveruren = 0;
            JaarBedTransportKost = 0;
            JaarBedHandelingsKost = 0;
        }
    }
}
