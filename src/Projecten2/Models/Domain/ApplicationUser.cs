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
        public string Email { get; set; }
        public string Organisatie { get; set; }
        public string Straat { get; set; }
        public string Nr { get; set; }
        public string Bus { get; set; }
        public string Postcode { get; set; }
        public string Plaats { get; set; }

    }
}
