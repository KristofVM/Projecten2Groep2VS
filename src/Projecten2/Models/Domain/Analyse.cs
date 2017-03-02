using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
        public Boolean archief { get; set; }

        public string balansFormat()
        {
            return balans.ToString("#,##0.##");
        }
        public string getMonth()
        {
            switch (datum.Month)
            {
                case 1 :
                    return "jan";
                    break;
                case 2:
                    return "feb";
                    break;
                case 3:
                    return "maart";
                    break;
                case 4:
                    return "april";
                    break;
                case 5:
                    return "mei";
                    break;
                case 6:
                    return "juni";
                    break;
                case 7:
                    return "juli";
                    break;
                case 8:
                    return "aug";
                    break;
                case 9:
                    return "sep";
                    break;
                case 10:
                    return "okt";
                    break;
                case 11:
                    return "nov";
                    break;
                case 12:
                    return "dec";
                    break;
                default:
                    return "maand0";
            }
        }
    }
}
