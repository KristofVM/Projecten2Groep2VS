using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projecten2.Models.Domain;

namespace Projecten2.Models.ViewModels.BatenViewModels
{
    public class BVraagDoubleViewModel
    {
        public int Vraag { get; set; }
        public string VraagTekst { get; set; }

        [Required]
        public int AnalyseId { get; set; }

        [Required(ErrorMessage = "Bedrag veld is verplicht")]
        [Display(Name = "Bedrag", Prompt = "Bedrag")]
        [Range(0, Double.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 0")]
        public double Bedrag { get; set; }

        public BVraagDoubleViewModel()
        {
        }

        public BVraagDoubleViewModel(Baten baten, int vraag) : this()
        {
            AnalyseId = baten.Analyse.AnalyseId;
            Vraag = vraag;
        }
    }
}
