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

        public EditViewModel()
        {
        }

        public EditViewModel(Analyse analyse) : this()
        {
            AnalyseId = analyse.AnalyseId;
            Naam = analyse.Naam;
            Bedrijf = analyse.Bedrijf;
            Afdeling = analyse.Afdeling;
        }
    }
}
