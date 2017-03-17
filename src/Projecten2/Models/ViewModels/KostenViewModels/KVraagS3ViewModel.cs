﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projecten2.Models.Domain;

namespace Projecten2.Models.ViewModels.KostenViewModels
{
    public class KVraagS3ViewModel
    {
        [Required]
        public int KostenId { get; set; }

        [Required(ErrorMessage = "Uren veld is verplicht")]
        [Display(Name = "Uren", Prompt = "Aantal")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1 voor {0}")]
        public int Uren { get; set; }

        [Required(ErrorMessage = "Bruto maandloon begeleider veld is verplicht")]
        [Display(Name = "Bruto maandloon begeleider", Prompt = "Bedrag")]
        [Range(1, Double.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 1 voor {0}")]
        public double BrutoMaandloonBegeleider { get; set; }

        public KVraagS3ViewModel()
        {
        }

        public KVraagS3ViewModel(Kosten kosten) : this()
        {
            KostenId = kosten.KostenId;

        }
    }
}
