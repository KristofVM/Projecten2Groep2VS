using System;
using System.Collections.Generic;
using System.Linq;
using Projecten2.Models.Domain.KostenVragen;

namespace Projecten2.Models.Domain
{
    public class Kosten
    {
        public int KostenId { get; set; }
        public Analyse Analyse { get; set; }

        public ICollection<KVraag1_0> Kvragen01 { get; set; }
        public ICollection<KVraag1_1> Kvragen1 { get; set; }
        public ICollection<KVraag2> Kvragen2 { get; set; }
        public ICollection<KVraag3> Kvragen3 { get; set; }
        public ICollection<KVraag4> Kvragen4 { get; set; }
        public ICollection<KVraag5> Kvragen5 { get; set; }
        public ICollection<KVraag6> Kvragen6 { get; set; }
        public ICollection<KVraag7> Kvragen7 { get; set; }
        public double Subtotaal()
        {
            double totaal = 0;
            for (int i = 1; i <= 11; i++)
            {
                totaal = totaal + GetTotaalKVragen(i);
            }
            return totaal;
        }
        public double GetTotaalKVragen(int vraag)
        {
            if (vraag == 1)
            {
                if (Kvragen01.Count == 0)
                    return 0;
                return Kvragen01.Sum(a => (double)(a.BrutoMaandloonFulltime)/(double)(a.Kosten.Analyse.UrenVoltijdsWerkweek)*(double)(a.AantalUrenPerWeek)*(1 + (double)(Analyse.PatronaleBijdrage) / 100));
            }
            if (vraag == 2)
            {
                if (Kvragen2.Count == 0)
                    return 0;
                return Kvragen2.Sum(a => a.Bedrag);
            }
            if (vraag == 3)
            {
                if (Kvragen3.Count == 0)
                    return 0;
                return Kvragen3.Sum(a => a.Bedrag);
            }
            if (vraag == 4)
            {
                if (Kvragen4.Count == 0)
                    return 0;
                return Kvragen4.Sum(a => a.Bedrag);
            }
            if (vraag == 5)
            {
                if (Kvragen5.Count == 0)
                    return 0;
                return Kvragen5.Sum(a => a.Bedrag);
            }
            if (vraag == 6)
            {
                if (Kvragen6.Count == 0)
                    return 0;
                return Kvragen6.Sum(a => (double) a.Uren / 152 * a.BrutoMaandloonBegeleider*(1 + (double) Analyse.PatronaleBijdrage/100));
            }
            if (vraag == 7)
            {
                if (Kvragen7.Count == 0)
                    return 0;
                return Kvragen7.Sum(a => a.Bedrag);
            }
            return 0;
        }
    }
}
