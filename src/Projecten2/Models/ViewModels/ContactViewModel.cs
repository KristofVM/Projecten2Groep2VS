using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projecten2.Models.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Dit veld is verplicht.")]
        [Display(Name = "Onderwerp", Prompt = "Onderwerp")]
        [StringLength(50, ErrorMessage = "De {0} moet minstens {2} en maximuum {1} karakters lang zijn.", MinimumLength = 1)]
        public string Onderwerp { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht.")]
        [Display(Name = "Bericht", Prompt = "Bericht")]
        [StringLength(500, ErrorMessage = "De {0} moet minstens {2} en maximuum {1} karakters lang zijn.", MinimumLength = 1)]
        public string Bericht { get; set; }
    }
}
