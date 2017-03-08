using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain
{
    public class Kosten
    {
        public int KostenId { get; set; }
        public int AnalyseId { get; set; }
        public Analyse Analyse { get; set; }
        public ICollection<KVraag01> Kvragen01 { get; set; }
        public ICollection<KVraag1> Kvragen1 { get; set; }
        public ICollection<KVraag2> Kvragen2 { get; set; }
        public ICollection<KVraag3> Kvragen3 { get; set; }
        public ICollection<KVraag4> Kvragen4 { get; set; }
        public ICollection<KVraag5> Kvragen5 { get; set; }
        public ICollection<KVraag6> Kvragen6 { get; set; }
        public ICollection<KVraag7> Kvragen7 { get; set; }
    }
}
