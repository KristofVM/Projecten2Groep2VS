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
    public class BVraag10ViewModel
    {
        public string Vraag1 { get; } = "Wat zijn de transportkosten van eventueel uitbesteedde zaken?";
        public string Vraag2 { get; } = "Wat zijn de logistieke handlingskosten van eventueel uitbesteedde zaken?";

        [Required]
        public int AnalyseId { get; set; }

        [Required(ErrorMessage = "Transportkosten veld is verplicht")]
        [Display(Name = "Bedrag transportkosten", Prompt = "Bedrag")]
        [Range(0, Double.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 0")]
        public double Vak1 { get; set; }

        [Required(ErrorMessage = "Handlingskosten veld is verplicht")]
        [Display(Name = "Bedrag handlingskosten", Prompt = "Bedrag")]
        [Range(0, Double.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 0")]
        public double Vak2 { get; set; }

        public BVraag10ViewModel()
        {
        }

        public BVraag10ViewModel(Baten baten, int vraag) : this()
        {
            AnalyseId = baten.Analyse.AnalyseId;
        }
    }
}
