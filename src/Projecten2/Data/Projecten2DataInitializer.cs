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

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                await InitializeUsers();
            }
        }
        public async Task InitializeUsers()
        {
            string eMailAddress = "kristofvanmoorter@hotmail.com";
            string naam = "van Moorter";
            string voornaam = "Kristof";
            string organisatie = "HoGent";
            string straat = "Langehaagstraat";
            string nr = "65";
            string bus = "";
            string postcode = "9308";
            string plaats = "Gijzegem";
            ApplicationUser user = new ApplicationUser { Email = eMailAddress,  Naam = naam, Voornaam = voornaam, Organisatie = organisatie, Straat = straat, Nr = nr, Bus = bus, Postcode = postcode, Plaats = plaats};
            await _userManager.CreateAsync(user, "letmein");

            eMailAddress = "jef_braem@hotmail.com";
            naam = "Braem";
            voornaam = "Jef";
            organisatie = "Chiro Hofstade";
            straat = "Hofstade-dorp";
            nr = "10";
            bus = "";
            postcode = "9308";
            plaats = "Hofstade";
            user = new ApplicationUser { Email = eMailAddress, Naam = naam, Voornaam = voornaam, Organisatie = organisatie, Straat = straat, Nr = nr, Bus = bus, Postcode = postcode, Plaats = plaats };
            await _userManager.CreateAsync(user, "letmein");
        }
    }
}