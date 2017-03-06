using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Projecten2.Models.Domain;

namespace Projecten2.Data
{
    public class Projecten2DataInitializer
    {
        private ApplicationDbContext _dbContext;
        private UserManager<ApplicationUser> _userManager;

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
                Analyse analyse1 = new Analyse();
                analyse1.afdeling = "kuisdienst";
                analyse1.bedrijf = "google";
                analyse1.datum = new DateTime(2017, 3, 25);
                analyse1.balans = 0;
                analyse1.naam = "GoogleAnalyseKuisdienst";
                analyse1.archief = false;
                _dbContext.Analyses.Add(analyse1);

                Analyse analyse2 = new Analyse();
                analyse2.afdeling = "advertising";
                analyse2.bedrijf = "tuc";
                analyse2.datum = new DateTime(2016, 1, 10);
                analyse2.balans = -3500;
                analyse2.naam = "TucAdvertising";
                analyse2.archief = false;
                _dbContext.Analyses.Add(analyse2);

                Analyse analyse3 = new Analyse();
                analyse3.afdeling = "production";
                analyse3.bedrijf = "apple";
                analyse3.datum = new DateTime(2014, 9, 13);
                analyse3.balans = 50000;
                analyse3.naam = "Production_Apple1";
                analyse3.archief = false;
                _dbContext.Analyses.Add(analyse3);

                Analyse analyse4 = new Analyse();
                analyse4.afdeling = "retail";
                analyse4.bedrijf = "action";
                analyse4.datum = new DateTime(2014, 9, 13);
                analyse4.balans = 1256960;
                analyse4.naam = "action1_retail";
                analyse4.archief = true;
                _dbContext.Analyses.Add(analyse4);

                Analyse analyse5 = new Analyse();
                analyse5.afdeling = "production";
                analyse5.bedrijf = "gabriëls";
                analyse5.datum = new DateTime(2012, 1, 20);
                analyse5.balans = 2500;
                analyse5.naam = "gabriëls production";
                analyse5.archief = true;
                _dbContext.Analyses.Add(analyse5);

                Analyse analyse6 = new Analyse();
                analyse6.afdeling = "store";
                analyse6.bedrijf = "colruyt";
                analyse6.datum = new DateTime(2013, 9, 13);
                analyse6.balans = 30064;
                analyse6.naam = "store_colruyt";
                analyse6.archief = true;
                _dbContext.Analyses.Add(analyse6);

                Analyse analyse7 = new Analyse();
                analyse7.afdeling = "lobby";
                analyse7.bedrijf = "hotel de paris";
                analyse7.datum = new DateTime(1997, 10, 27);
                analyse7.balans = -14750;
                analyse7.naam = "lobby_hotel de paris";
                analyse7.archief = true;
                _dbContext.Analyses.Add(analyse7);

                Analyse analyse8 = new Analyse();
                analyse8.afdeling = "management";
                analyse8.bedrijf = "belfius";
                analyse8.datum = new DateTime(2015, 6, 30);
                analyse8.balans = 3560000;
                analyse8.naam = "belfius management";
                analyse8.archief = true;
                _dbContext.Analyses.Add(analyse8);

                _dbContext.SaveChanges();
            }
        }
        public async Task InitializeUsers()
        {
            string eMailAddress = "kristofvanmoorter@hotmail.com";
            string naam = "van Moorter";
            string voornaam = "Kristof";
            string organisatie = "HoGent";
            string straat = "Langehaagstraat";
            int nr = 65;
            string bus = "";
            string postcode = "9308";
            string plaats = "Gijzegem";
            ApplicationUser user = new ApplicationUser { UserName = eMailAddress, Email = eMailAddress,  naam = naam, voornaam = voornaam, organisatie = organisatie, straat = straat, nr = nr, bus = bus, postcode = postcode, plaats = plaats};
            await _userManager.CreateAsync(user, "letmein");

            eMailAddress = "jef_braem@hotmail.com";
            naam = "Braem";
            voornaam = "Jef";
            organisatie = "Chiro Hofstade";
            straat = "Hofstade-dorp";
            nr = 10;
            bus = "";
            postcode = "9308";
            plaats = "Hofstade";
            user = new ApplicationUser { UserName = eMailAddress, Email = eMailAddress, naam = naam, voornaam = voornaam, organisatie = organisatie, straat = straat, nr = nr, bus = bus, postcode = postcode, plaats = plaats };
            await _userManager.CreateAsync(user, "P@ssword1");
        }
    }
}