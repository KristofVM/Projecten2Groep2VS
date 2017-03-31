using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projecten2.Models.Domain;

namespace Projecten2.Models.ViewModels.BatenViewModels
{
    public class BVraagS1ViewModel
    {
        public int Vraag { get; }
        [Required]
        public int BatenId { get; set; }

        [Required(ErrorMessage = "Beschrijving veld is verplicht")]
        [Display(Name = "Beschrijving", Prompt = "Beschrijving")]
        [StringLength(50, ErrorMessage = "De {0} moet minstens {2} en maximuum {1} karakters lang zijn", MinimumLength = 3)]
        public string Beschrijving { get; set; }

        [Required(ErrorMessage = "Bedrag veld is verplicht")]
        [Display(Name = "Bedrag", Prompt = "Bedrag")]
        [Range(1, Double.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1")]
        public double Bedrag { get; set; }

        public BVraagS1ViewModel()
        {
        }

        public BVraagS1ViewModel(Baten baten, int vraag) : this()
        {
            BatenId = baten.BatenId;
            Vraag = vraag;
        }
    }
}
