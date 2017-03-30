using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projecten2.Models.Domain;

namespace Projecten2.Models.ViewModels.BatenViewModels
{
    public class JaarBedSubsWerkOmgViewModel
    {
        [Required]
        public int AnalyseId { get; set; }

        public string Vraag { get; } = "Welk bedrag krijgt u aan subsidies voor eventuele aanpassingen aan de werkomgeving?";

        [Required(ErrorMessage = "Bedrag veld is verplicht")]
        [Display(Name = "Bedrag", Prompt = "Bedrag")]
        [Range(0, Double.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 0")]
        public double Bedrag { get; set; }

        public JaarBedSubsWerkOmgViewModel()
        {
        }

        public JaarBedSubsWerkOmgViewModel(Baten baten) : this()
        {
            AnalyseId = baten.Analyse.AnalyseId;
            Bedrag = baten.JaarBedSubsWerkOmg;
        }
    }
}
