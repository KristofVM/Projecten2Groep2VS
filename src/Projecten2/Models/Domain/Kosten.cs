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
            double totaalV1 = 0,
                totaalV2 = 0,
                totaalV3 = 0,
                totaalV4 = 0,
                totaalV5 = 0,
                totaalV6 = 0,
                totaalV7 = 0;

            if (Kvragen2.Count > 0)
                totaalV2 = getTotaalKVragenS4(2);
            if (Kvragen3.Count > 0)
                totaalV3 = getTotaalKVragenS4(3);
            if (Kvragen4.Count > 0)
                totaalV4 = getTotaalKVragenS4(4);
            if (Kvragen5.Count > 0)
                totaalV5 = getTotaalKVragenS4(5);
            if (Kvragen7.Count > 0)
                totaalV7 = getTotaalKVragenS4(7);

            return totaalV1 + totaalV2 + totaalV3 + totaalV4 + totaalV5 + totaalV6 + totaalV7;
        }
        public double getTotaalKVragenS4(int vraag)
        {
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
