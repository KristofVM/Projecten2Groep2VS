using System.Collections.Generic;
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
        public string GetVraag(int vraag)
        {
            switch (vraag)
            {
                case 1:
                    return ""
                    ; break;
                case 10:
                    return ""
                ; break;
                case 2:
                    return ""
                ; break;
                case 3:
                    return ""
                ; break;
                case 4:
                    return ""
                ; break;
                case 5:
                    return ""
                ; break;
                case 6:
                    return ""
                ; break;
                case 7:
                    return ""
                ; break;
                default:
                    return ""
                ; break;
            }
        }
    }
}
