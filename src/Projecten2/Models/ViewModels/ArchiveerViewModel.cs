using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projecten2.Models.Domain;

namespace Projecten2.Models.ViewModels
{
    public class ArchiveerViewModel
    {
        public int AnalyseId { get; set; }

        public ArchiveerViewModel()
        {
            
        }

        public ArchiveerViewModel(Analyse analyse) : this()
        {
            AnalyseId = analyse.AnalyseId;
        }
    }
}
