using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.Domain
{
    public class Analyse
    {
        public int analyseId { get; set; }
        public string naam { get; set; }
        public string bedrijf { get; set; }
        public string afdeling { get; set; }
        public DateTime datum { get; set; }
        public int balans { get; set; }
        public int gebruikerId { get; set; }
    }
}
