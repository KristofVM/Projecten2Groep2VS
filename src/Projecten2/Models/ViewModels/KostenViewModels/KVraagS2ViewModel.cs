using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projecten2.Models.Domain;

namespace Projecten2.Models.ViewModels.KostenViewModels
{
    public class KVraagS2ViewModel
    {
        public int Vraag { get; }
        [Required]
        public int AnalyseId { get; set; }

        [Required(ErrorMessage = "Beschrijving veld is verplicht")]
        [Display(Name = "Beschrijving", Prompt = "Beschrijving")]
        [StringLength(50, ErrorMessage = "De {0} moet minstens {2} en maximuum {1} karakters lang zijn", MinimumLength = 3)]
        public string Beschrijving { get; set; }

        [Required(ErrorMessage = "Jaarbedrag veld is verplicht")]
        [Display(Name = "Jaarbedrag", Prompt = "Jaarbedrag")]
        [Range(1, Double.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1")]
        public double JaarBedrag { get; set; }

        public KVraagS2ViewModel()
        {
        }

        public KVraagS2ViewModel(Kosten kosten, int vraag) : this()
        {
            AnalyseId = kosten.Analyse.AnalyseId;
            Vraag = vraag;
        }
    }
}
