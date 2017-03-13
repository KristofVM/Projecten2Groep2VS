using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Projecten2.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Organisatie { get; set; }
        public string Straat { get; set; }
        public int Nr { get; set; }
        public string Bus { get; set; }
        public int Postcode { get; set; }
        public string Plaats { get; set; }
        public ICollection<Analyse> Analyses { get; set; }
    }
}
