using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Projecten2.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string naam { get; set; }
        public string voornaam { get; set; }
        public string email { get; set; }
        public string organisatie { get; set; }
        public string straat { get; set; }
        public int nr { get; set; }
        public string bus { get; set; }
        public int postcode { get; set; }
        public string plaats { get; set; }
    }
}
