using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projecten2.Models.Domain;

namespace Projecten2.Models.ViewModels.BatenViewModels
{
    public class BVraagS2ViewModel
    {
        public int Vraag { get; }
        [Required]
        public int BatenId { get; set; }

        [Required(ErrorMessage = "Uren veld is verplicht")]
        [Display(Name = "Uren", Prompt = "getal")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1 voor {0}")]
        public int Uren { get; set; }

        [Required(ErrorMessage = "Bruto maandloon fulltime veld is verplicht")]
        [Display(Name = "Bruto maandloon fulltime", Prompt = "getal")]
        [Range(1, Double.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1 voor {0}")]
        public double BrutoMaandloonFulltime { get; set; }

        public BVraagS2ViewModel()
        {
        }

        public BVraagS2ViewModel(Baten baten, int vraag) : this()
        {
            BatenId = baten.BatenId;
            Vraag = vraag
        }
    }
}
