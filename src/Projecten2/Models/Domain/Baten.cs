using System.Collections.Generic;
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

        public string GetVraag(int vraag)
        {
            switch (vraag)
            {
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
                case 8:
                    return ""
                ; break;
                case 9:
                    return ""
                ; break;
                case 101:
                    return ""
                ; break;
                case 102:
                    return ""
                ; break;
                case 11:
                    return ""
                ; break;
                default:
                    return ""
                ; break;
            }
        }
    }
}
