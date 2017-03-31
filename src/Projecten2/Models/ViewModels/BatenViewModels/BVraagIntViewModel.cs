﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projecten2.Models.Domain;

namespace Projecten2.Models.ViewModels.BatenViewModels
{
    public class BVraagIntViewModel
    {
        public int Vraag { get; set; }

        [Required]
        public int AnalyseId { get; set; }

        [Required(ErrorMessage = "Bedrag veld is verplicht")]
        [Display(Name = "Bedrag", Prompt = "Bedrag")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Geef een cijfer hoger dan 0")]
        public int Bedrag { get; set; }

        public BVraagIntViewModel()
        {
        }

        public BVraagIntViewModel(Baten baten) : this()
        {
            AnalyseId = baten.Analyse.AnalyseId;
        }
    }
}
