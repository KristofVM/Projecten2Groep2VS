using System;
using System.Linq;

namespace Projecten2.Models.Domain
{
    public class Analyse
    {
        public int AnalyseId { get; set; }
        
        public string Bedrijf { get; set; }
        public string Afdeling { get; set; }
        public DateTime Datum { get; set; }
        public double Balans { get; set; }
        public int PatronaleBijdrage { get; set; } //standaard 35%
        public int UrenVoltijdsWerkweek { get; set; } //Vraag 1
        public Boolean Archief { get; set; }

        public string ApplicationUserId { get; set; }

        public Kosten Kosten { get; set; }
        public Baten Baten { get; set; }

        public string getBalansFormat()
        {
            Balans = Baten.subtotaal() - Kosten.Subtotaal();
            return Balans.ToString("#,##0.##");
        }

        public string getBatenFormat()
        {
            return Baten.subtotaal().ToString("#,##0.##");
        }

        public string getKostenFormat()
        {
            return Kosten.Subtotaal().ToString("#,##0.##");
        }

        public string getKVragenFormat(int vraag)
        {
            return Kosten.GetTotaalKVragen(vraag) == 0 ? "-" : Kosten.GetTotaalKVragen(vraag).ToString("#,##0.##");
        }
        public string getBVragenFormat(int vraag)
        {
            return Baten.getTotaalBVragen(vraag) == 0 ? "-" : Baten.getTotaalBVragen(vraag).ToString("#,##0.##");
        }
        public string getMonth()
        {
            switch (Datum.Month)
            {
                case 1: return "jan"; break;
                case 2: return "feb"; break;
                case 3: return "maart"; break;
                case 4: return "april"; break;
                case 5: return "mei"; break;
                case 6: return "juni"; break;
                case 7: return "juli"; break;
                case 8: return "aug"; break;
                case 9: return "sep"; break;
                case 10: return "okt"; break;
                case 11: return "nov"; break;
                case 12: return "dec"; break;
                default: return "MonthErr";
            }
        }

        public Analyse()
        {
            Baten = new Baten();
            Baten.Analyse = this;
            Kosten = new Kosten();
            Kosten.Analyse = this;

            Datum = DateTime.Now;
            Balans = 0;
            Archief = false;
            PatronaleBijdrage = 35;
            UrenVoltijdsWerkweek = 38;
        }
    }
}
