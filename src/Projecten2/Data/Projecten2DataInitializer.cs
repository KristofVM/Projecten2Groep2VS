using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Projecten2.Models.Domain;

namespace Projecten2.Data
{
    public class Projecten2DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public Projecten2DataInitializer(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeUsers()
        {
            string eMailAddress = "kristofvanmoorter@hotmail.com";
            string naam = "van Moorter";
            string voornaam = "Kristof";
            ApplicationUser user = new ApplicationUser { Email = eMailAddress,  Naam = naam, Voornaam = voornaam};
            await _userManager.CreateAsync(user, "letmein");

            eMailAddress = "jef_braem@hotmail.com";
            naam = "Braem";
            voornaam = "Jef";
            user = new ApplicationUser { Email = eMailAddress, Naam = naam, Voornaam = voornaam };
            await _userManager.CreateAsync(user, "letmein");
        }
    }
}