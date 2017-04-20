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

        public double subtotaal()
        {
            double jaarbedswo = 0;
            double jaarbedep = 0;
            double jaarbedo = 0;
            if (JaarBedSubsWerkOmg > 0)
                jaarbedswo = JaarBedSubsWerkOmg;
            if (JaarBedExtraProd > 0)
                jaarbedep = JaarBedExtraProd;
            if (JaarBedOveruren > 0)
                jaarbedo = JaarBedOveruren;

            double totaal = jaarbedo + jaarbedep + jaarbedswo;
            return totaal;
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
