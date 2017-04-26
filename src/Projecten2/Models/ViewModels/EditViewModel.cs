using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projecten2.Models.Domain;

namespace Projecten2.Models.ViewModels
{
    public class EditViewModel
    {
        public int AnalyseId { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht.")]
        [Display(Name = "Bedrijf", Prompt = "Bedrijf")]
        [StringLength(50, ErrorMessage = "De {0} moet minstens {2} en maximuum {1} karakters lang zijn.", MinimumLength = 3)]
        public string Bedrijf { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht.")]
        [Display(Name = "Afdeling", Prompt = "Afdeling")]
        [StringLength(50, ErrorMessage = "De {0} moet minstens {2} en maximuum {1} karakters lang zijn.", MinimumLength = 3)]
        public string Afdeling { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht.")]
        [Display(Name = "Patronale Bijdrage (%)")]
        [Range(0, 100, ErrorMessage = "Geef een cijfer tussen 0 en 100.")]
        public int PatronaleBijdrage { get; set; } = 35;

        [Required(ErrorMessage = "Dit veld is verplicht.")]
        [Display(Name = "Uren voltijdse werkweek")]
        [Range(1, 48, ErrorMessage = "Geef een cijfer tussen 1 en 48.")]
        public int UrenVoltijdsWerkweek { get; set; } = 38;

        public EditViewModel()
        {
        }

        public EditViewModel(Analyse analyse) : this()
        {
            AnalyseId = analyse.AnalyseId;
            Bedrijf = analyse.Bedrijf;
            Afdeling = analyse.Afdeling;
            PatronaleBijdrage = analyse.PatronaleBijdrage;
        }
    }
}
