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
        public double subtotaal()
        {
            double totaal = 0;
            for (int i = 1; i <= 11; i++)
            {
                totaal = totaal + getTotaalKVragen(i);
            }
            return totaal;
        }
        public double getTotaalKVragen(int vraag)
        {
            if (vraag == 1)
            {
                return 0;
                if (Kvragen2.Count == 0)
                    return 0;
            }
            if (vraag == 2)
            {
                if (Kvragen2.Count == 0)
                    return 0;
                return Kvragen2.ToList().Sum(a => a.Bedrag);
            }
            if (vraag == 3)
            {
                if (Kvragen3.Count == 0)
                    return 0;
                return Kvragen3.ToList().Sum(a => a.Bedrag);
            }
            if (vraag == 4)
            {
                if (Kvragen4.Count == 0)
                    return 0;
                return Kvragen4.ToList().Sum(a => a.Bedrag);
            }
            if (vraag == 5)
            {
                if (Kvragen5.Count == 0)
                    return 0;
                return Kvragen5.ToList().Sum(a => a.Bedrag);
            }
            if (vraag == 7)
            {
                if (Kvragen7.Count == 0)
                    return 0;
                return Kvragen7.ToList().Sum(a => a.Bedrag);
            }
            throw new NotImplementedException();
        }
    }
}
