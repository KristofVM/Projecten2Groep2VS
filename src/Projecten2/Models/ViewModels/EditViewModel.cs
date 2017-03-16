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

        [Required]
        [Display(Name = "Naam", Prompt = "Naam")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Naam { get; set; }

        [Required]
        [Display(Name = "Bedrijf", Prompt = "Bedrijf")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Bedrijf { get; set; }

        [Required]
        [Display(Name = "Afdeling", Prompt = "Afdeling")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Afdeling { get; set; }

        [Required]
        [Display(Name = "Patronale Bijdrage")]
        [Range(0, 100, ErrorMessage = "Please enter a number between 0 and 100.")]
        public int PatronaleBijdrage { get; set; } = 35;

        [Required]
        [Display(Name = "Uren voltijdse werkweek")]
        [Range(1, 48, ErrorMessage = "Please enter a number between 1 and 48.")]
        public int UrenVoltijdsWerkweek { get; set; } = 38;

        public EditViewModel()
        {
        }

        public EditViewModel(Analyse analyse) : this()
        {
            AnalyseId = analyse.AnalyseId;
            Naam = analyse.Naam;
            Bedrijf = analyse.Bedrijf;
            Afdeling = analyse.Afdeling;
            PatronaleBijdrage = analyse.PatronaleBijdrage;
        }
    }
}
