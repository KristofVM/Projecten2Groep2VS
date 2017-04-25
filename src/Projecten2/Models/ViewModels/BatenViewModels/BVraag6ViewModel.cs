using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projecten2.Models.Domain;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Projecten2.Models.ViewModels.BatenViewModels
{
    public class BVraag6ViewModel
    {
        public string VraagTekst { get; } = "Wat zijn de transportkosten van eventueel uitbesteedde zaken?";

        [Required]
        public int AnalyseId { get; set; }

        [Required(ErrorMessage = "Bedrag veld is verplicht")]
        [Display(Name = "Bedrag", Prompt = "Bedrag")]
        [Range(0, Double.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 0")]
        public double Vak1 { get; set; }

        [Required(ErrorMessage = "Percent veld is verplicht")]
        [Display(Name = "Percent", Prompt = "Percent")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 0")]
        public int Vak2 { get; set; }

        public BVraag6ViewModel()
        {
        }

        public BVraag6ViewModel(Baten baten) : this()
        {
            AnalyseId = baten.Analyse.AnalyseId;
        }
    }
}
