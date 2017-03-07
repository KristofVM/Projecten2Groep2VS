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
    }
}
