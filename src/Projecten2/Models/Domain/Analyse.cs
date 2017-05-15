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
        public double KostenTotaal { get; set; }
        public double BatenTotaal { get; set; }
        public int PatronaleBijdrage { get; set; } //standaard 35%
        public int UrenVoltijdsWerkweek { get; set; } //Vraag 1
        public Boolean Archief { get; set; }

        public string ApplicationUserId { get; set; }

        public Kosten Kosten { get; set; }
        public Baten Baten { get; set; }

        public void updateBalans()
        {
            BatenTotaal = Baten.subtotaal();
            KostenTotaal = Kosten.Subtotaal();
        }
        public string getBalansFormat()
        {
            return (Baten.subtotaal() - Kosten.Subtotaal()).ToString("#,##0.##");
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

        public double getWidthGroen()
        {
            return Math.Round((Baten.subtotaal() / (Baten.subtotaal() + Kosten.Subtotaal()) * 100));
        }
        public double getWidthRood()
        {
            return 100 - getWidthGroen();
        }
        public string getMonth()
        {
            switch (Datum.Month)
            {
                case 1: return "jan";
                case 2: return "feb";
                case 3: return "maart";
                case 4: return "april";
                case 5: return "mei";
                case 6: return "juni";
                case 7: return "juli";
                case 8: return "aug";
                case 9: return "sep";
                case 10: return "okt";
                case 11: return "nov";
                case 12: return "dec";
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
            KostenTotaal = 0;
            BatenTotaal = 0;
            Archief = false;
            PatronaleBijdrage = 35;
            UrenVoltijdsWerkweek = 38;
        }
    }
}
