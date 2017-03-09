using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Projecten2.Models.Domain
{
    public class Baten
    {
        public int BatenId { get; set; }
        public int AnalyseId { get; set; }
        public Analyse Analyse { get; set; }
        public int UrenVoltijdsWerkweek { get; set; } //Vraag 1
        public double JaarBedSubsWerkOmg { get; set; } //Vraag 2
        public double JaarBedOmzetVerlies { get; set; } //Vraag 6
        public double ProcentBesparing { get; set; } //Vraag 6
        public double JaarBedExtraProd { get; set; } //Vraag 7
        public double JaarBedOveruren { get; set; } //Vraag 8
        public double JaarBedTransportKost { get; set; } //Vraag 10.1
        public double JaarBedHandelingsKost { get; set; } //Vraag 10.2
        //public ICollection<BVraag3> Bvragen3 { get; set; }
        //public ICollection<BVraag4> Bvragen4 { get; set; }
        //public ICollection<BVraag5> Bvragen5 { get; set; }
        //public ICollection<BVraag9> Bvragen9 { get; set; }
        //public ICollection<BVraag11> Bvragen11 { get; set; }
    }
}
