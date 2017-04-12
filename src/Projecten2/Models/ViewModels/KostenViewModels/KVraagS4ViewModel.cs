using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projecten2.Models.Domain;

namespace Projecten2.Models.ViewModels.KostenViewModels
{
    public class KVraagS4ViewModel
    {
        public int Vraag { get; }
        [Required]
        public int AnalyseId { get; set; }

        [Required(ErrorMessage = "Type veld is verplicht")]
        [Display(Name = "Type", Prompt = "Type")]
        [StringLength(50, ErrorMessage = "De {0} moet minstens {2} en maximuum {1} karakters lang zijn", MinimumLength = 3)]
        public string Type { get; set; }

        [Required(ErrorMessage = "Bedrag veld is verplicht")]
        [Display(Name = "Bedrag", Prompt = "Bedrag")]
        [Range(1, Double.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1 voor {0}")]
        public double Bedrag { get; set; }

        public KVraagS4ViewModel()
        {
        }

        public KVraagS4ViewModel(Kosten kosten, int vraag) : this()
        {
            AnalyseId = kosten.Analyse.AnalyseId;
            Vraag = vraag;
        }
    }
}
