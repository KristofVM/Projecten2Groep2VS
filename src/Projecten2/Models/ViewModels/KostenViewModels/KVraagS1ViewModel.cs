using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projecten2.Models.Domain;

namespace Projecten2.Models.ViewModels.KostenViewModels
{
    public class KVraagS1ViewModel
    {
        public string VraagTekst { get; set; } = "Welke nieuwe functies zet u in?";
        [Required]
        public int AnalyseId { get; set; }

        [Required(ErrorMessage = "Functie veld is verplicht")]
        [Display(Name = "Functie", Prompt = "Functie")]
        [StringLength(50, ErrorMessage = "De {0} moet minstens {2} en maximuum {1} karakters lang zijn", MinimumLength = 2)]
        public string Functie { get; set; }

        [Required(ErrorMessage = "Bedrag veld is verplicht")]
        [Display(Name = "Wekelijkse uren", Prompt = "Aantal")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1 voor {0}")]
        public int AantalUrenPerWeek { get; set; }

        [Required(ErrorMessage = "Bruto maandloon fulltime veld is verplicht")]
        [Display(Name = "Bruto maandloon fulltime", Prompt = "bedrag")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1 voor {0}")]
        public int BrutoMaandloonFulltime { get; set; }

        [Required(ErrorMessage = "Doelgroep veld is verplicht")]
        [Display(Name = "Doelgroep")]
        public int Doelgroep { get; set; }

        [Required(ErrorMessage = "Bedrag veld is verplicht")]
        [Display(Name = "Vlaamse ondersteunings premie")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1 voor {0}")]
        public int VlaamseOndPremie { get; set; }

        [Required(ErrorMessage = "Bedrag veld is verplicht")]
        [Display(Name = "Aantal maanden IBO", Prompt = "Aantal")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1 voor {0}")]
        public int AantalMaandenIBO { get; set; }

        [Required(ErrorMessage = "Bedrag veld is verplicht")]
        [Display(Name = "Totale productiviteitspremie IBO", Prompt = "bedrag")]
        [Range(1, Double.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1 voor {0}")]
        public double TotaleProductiviteitsPremie { get; set; }

        public KVraagS1ViewModel()
        {
        }

        public KVraagS1ViewModel(Kosten kosten) : this()
        {
            AnalyseId = kosten.Analyse.AnalyseId;
        }
    }
}
