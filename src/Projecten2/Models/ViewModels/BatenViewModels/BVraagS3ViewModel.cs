using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projecten2.Models.Domain;

namespace Projecten2.Models.ViewModels.BatenViewModels
{
    public class BVraagS3ViewModel
    {
        [Required]
        public int BatenId { get; set; }


        [Required(ErrorMessage = "Type besparing is verplicht")]
        [Display(Name = "Type besparing", Prompt = "Type besparing")]
        [StringLength(50, ErrorMessage = "De {0} moet minstens {2} en maximuum {1} karakters lang zijn", MinimumLength = 3)]
        public string TypeBesparing { get; set; }

        [Required(ErrorMessage = "Bedrag is verplicht")]
        [Display(Name = "Jaarbedrag", Prompt = "Jaarbedrag")]
        [Range(1, Double.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1")]
        public double JaarBedrag { get; set; }

        public BVraagS3ViewModel()
        {
        }

        public BVraagS3ViewModel(Baten baten) : this()
        {
            BatenId = baten.BatenId;

        }
    }
}
