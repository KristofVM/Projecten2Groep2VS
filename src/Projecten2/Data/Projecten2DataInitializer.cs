﻿using System;
using System.Collections;
using System.Collections.Generic;
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
                InitializeDoelgroepen();

                ICollection<Analyse> analysen = new List<Analyse>();

                Analyse analyse1 = new Analyse();
                analyse1.Afdeling = "kuisdienst";
                analyse1.Bedrijf = "google";
                analyse1.Datum = new DateTime(2017, 3, 25);
                analyse1.Archief = false;
                analysen.Add(analyse1);

                string eMailAddress = "chirohofstadeaalst@gmail.com";
                string naam = "Braem";
                string voornaam = "Jef";
                string organisatie = "Chiro Sinte Goedele";
                string straat = "Hofstade-dorp";
                int nr = 11;
                string bus = "";
                int postcode = 9308;
                string plaats = "Hofstade";
                ApplicationUser user2 = new ApplicationUser { UserName = eMailAddress, Email = eMailAddress, Naam = naam, Voornaam = voornaam, Organisatie = organisatie, Straat = straat, Nr = nr, Bus = bus, Postcode = postcode, Plaats = plaats, Analyses = analysen};
                
                await _userManager.CreateAsync(user2, "P@ssword1");
                
                _dbContext.SaveChanges();
            }
        }

        public async Task InitializeUsers()
        {
            Random rnd = new Random();
            List<string> voornamen = this.getVoornamen();
            List<string> namen = this.getNamen();
            List<string> organisaties= this.getOrganisaties();
            List<string> straten = this.getStraten();
            List<string> plaatsen = this.getPlaatsen();
            List<int> postcodes = this.getPostcodes();
            List<string> tekens = this.getTeken();
            List<string> email = this.getEmail();


            for (int i = 0; i <= 1200; i++)
            {
                string voornaam = voornamen[rnd.Next(0, voornamen.Count)];
                string naam = namen[rnd.Next(0, namen.Count)];
                string organisatie = organisaties[rnd.Next(0, organisaties.Count)];
                string straat = straten[rnd.Next(0, straten.Count)];
                int randomplaats = rnd.Next(0, plaatsen.Count);
                string plaats = namen[randomplaats];
                int postcode = postcodes[randomplaats];
                int nr = rnd.Next(0, 300);

                string eMailAddress = voornaam + tekens[rnd.Next(0, tekens.Count)] + naam + "@" + email[rnd.Next(0, email.Count)];

                ApplicationUser user0 = new ApplicationUser { UserName = eMailAddress, Email = eMailAddress, Naam = naam, Voornaam = voornaam, Organisatie = organisatie, Straat = straat, Nr = nr, Bus = "", Postcode = postcode, Plaats = plaats };
                await _userManager.CreateAsync(user0, "P@ssword1");
            }
        }
        public async Task InitializeUsersmlkj()
        {
            string eMailAddress = "kristofvanmoorter@hotmail.com";
            string naam = "van Moorter";
            string voornaam = "Kristof";
            string organisatie = "HoGent";
            string straat = "Langehaagstraat";
            int nr = 65;
            string bus = "12";
            int postcode = 9308;
            string plaats = "Gijzegem";
            ApplicationUser user0 = new ApplicationUser { UserName = eMailAddress, Email = eMailAddress,  Naam = naam, Voornaam = voornaam, Organisatie = organisatie, Straat = straat, Nr = nr, Bus = bus, Postcode = postcode, Plaats = plaats};
            await _userManager.CreateAsync(user0, "P@ssword1");

            eMailAddress = "jef_braem@hotmail.com";
            naam = "Braem";
            voornaam = "Jef";
            organisatie = "Chiro Hofstade";
            straat = "Hofstade-dorp";
            nr = 10;
            bus = "";
            postcode = 9308;
            plaats = "Hofstade";
            ApplicationUser user1 = new ApplicationUser { UserName = eMailAddress, Email = eMailAddress, Naam = naam, Voornaam = voornaam, Organisatie = organisatie, Straat = straat, Nr = nr, Bus = bus, Postcode = postcode, Plaats = plaats };
            await _userManager.CreateAsync(user1, "P@ssword1");
        }

        public void InitializeDoelgroepen()
        {
            Doelgroep doelgroep = new Doelgroep();
            doelgroep.DoelgroepText = "Andere";
            doelgroep.DoelgroepValue = 0;
            doelgroep.DoelgroepMaxLoon = 0;
            _dbContext.Doelgroepen.Add(doelgroep);

            Doelgroep doelgroep1 = new Doelgroep();
            doelgroep1.DoelgroepText = "< 25 laaggeschoold";
            doelgroep1.DoelgroepValue = 1550;
            doelgroep1.DoelgroepMaxLoon = 2500;
            _dbContext.Doelgroepen.Add(doelgroep1);

            Doelgroep doelgroep2 = new Doelgroep();
            doelgroep2.DoelgroepText = "< 25 middengeschoold";
            doelgroep2.DoelgroepValue = 1000;
            doelgroep2.DoelgroepMaxLoon = 2500;
            _dbContext.Doelgroepen.Add(doelgroep2);

            Doelgroep doelgroep3 = new Doelgroep();
            doelgroep3.DoelgroepText = "55 - 60 jaar";
            doelgroep3.DoelgroepValue = 1150;
            doelgroep3.DoelgroepMaxLoon = 4466.66;
            _dbContext.Doelgroepen.Add(doelgroep3);

            Doelgroep doelgroep4 = new Doelgroep();
            doelgroep4.DoelgroepText = "> 60 jaar";
            doelgroep4.DoelgroepValue = 1500;
            doelgroep4.DoelgroepMaxLoon = 4466.66;
            _dbContext.Doelgroepen.Add(doelgroep4);

            _dbContext.SaveChanges();
        }
        public List<string> getEmail()
        {
            List<string> s = new List<string>();
            s.Add("gmail.com");
            s.Add("gmail.be");
            s.Add("hotmail.com");
            s.Add("hotmail.be");
            s.Add("skynet.be");
            s.Add("telenet.be");
            return s;
        }
        public List<string> getTeken()
        {
            List<string> s = new List<string>();
            s.Add(".");
            s.Add("-");
            s.Add("_");
            s.Add("");
            return s;
        }
        public List<string> getStraten()
        {
            List<string> s = new List<string>();
            s.Add("Kerkstraat");
            s.Add("Schoolstraat");
            s.Add("Molenstraat");
            s.Add("Dorpstraat");
            s.Add("Molenweg");
            s.Add("Julianastraat");
            s.Add("Parallelweg");
            s.Add("Nieuwstraat");
            s.Add("Wilhelminastraat");
            s.Add("Sportlaan");
            s.Add("Ijsbroekstraat");
            s.Add("Konijnenberg");
            s.Add("Dorpweg");
            s.Add("Asserendries");
            s.Add("Binnenstraat");
            s.Add("Anjerstraat");
            s.Add("Fazantenlaan");
            s.Add("Grootstraat");
            s.Add("Heuvel");
            s.Add("Kalfstraat");
            s.Add("Katelijnestraat");
            s.Add("Kammenkouterstraat");
            s.Add("Meirweg");
            return s;
        }
        public List<string> getPlaatsen()
        {
            List<string> s = new List<string>();
            s.Add("Gijzegem");
            s.Add("Hofstade");
            s.Add("Brussel");
            s.Add("Aalst");
            s.Add("Antwerpen");
            s.Add("Gent");
            s.Add("Hasselt");
            s.Add("Brugge");
            s.Add("Aaigem");
            s.Add("Dendermonde");
            s.Add("Herdersem");
            return s;
        }
        public List<int> getPostcodes()
        {
            List<int> s = new List<int>();
            s.Add(9308);
            s.Add(9308);
            s.Add(1000);
            s.Add(9300);
            s.Add(2000);
            s.Add(9000);
            s.Add(3500);
            s.Add(8000);
            s.Add(9420);
            s.Add(9200);
            s.Add(9310);
            return s;
        }
        public List<string> getOrganisaties()
        {
            List<string> s = new List<string>();
            s.Add("Adecco");
            s.Add("Konvert");
            s.Add("Creyfs");
            s.Add("AGO Interim");
            s.Add("Accent");
            s.Add("Randstad");
            s.Add("Acede");
            s.Add("Asap.be");
            s.Add("Artec Interim");
            s.Add("Continu");
            s.Add("Cofi");
            s.Add("Ergoflex");
            s.Add("Edco");
            s.Add("Go4Jobs");
            s.Add("Hays");
            s.Add("IBC Personeelsdienst");
            s.Add("Harvey Nash");
            s.Add("Job Talent");
            s.Add("Job Expert");
            s.Add("Jobconnection");
            s.Add("Link 4 Jobs");
            s.Add("M Interim");
            s.Add("Nett Staff");
            s.Add("Nestor");
            s.Add("Payper Industrie");
            s.Add("Passion Works !");
            s.Add("Robert Half");
            s.Add("Runtime");
            s.Add("Service Plus Service");
            s.Add("Segers Select");
            s.Add("Runtime");
            s.Add("Work Express");
            return s;
        }
        public List<string> getVoornamen()
        {
            List<string> s = new List<string>();
            s.Add("Kristof");
            s.Add("Jordi");
            s.Add("Jef");
            s.Add("Bastian");
            s.Add("Davy");
            s.Add("Brent");
            s.Add("Michiel");
            s.Add("Hanne");
            s.Add("elien");
            s.Add("Stijn");
            s.Add("Rudy");
            s.Add("Mila");
            s.Add("Emma");
            s.Add("Olivia");
            s.Add("Louise");
            s.Add("Elise");
            s.Add("Ella");
            s.Add("Marie");
            s.Add("Noor");
            s.Add("Nora");
            s.Add("Anna");
            s.Add("Julie");
            s.Add("Lina");
            s.Add("Juliette");
            s.Add("Lena");
            s.Add("Elena");
            s.Add("Lotte");
            s.Add("Charlotte");
            s.Add("Alice");
            s.Add("Liv");
            s.Add("Amber");
            s.Add("Amélie");
            s.Add("Fien");
            s.Add("Lore");
            s.Add("Nina");
            s.Add("Renée");
            s.Add("Lisa");
            s.Add("Lily");
            s.Add("Camille");
            s.Add("Axelle");
            s.Add("Laura");
            s.Add("Luna");
            s.Add("Billie");
            s.Add("Mona");
            s.Add("Amira");
            s.Add("Kato");
            s.Add("Janne");
            s.Add("Mia");
            s.Add("Aya");
            s.Add("Elisa");
            s.Add("Lara");
            s.Add("Lucas");
            s.Add("Finn");
            s.Add("Louis");
            s.Add("Liam");
            s.Add("Arthur");
            s.Add("Noah");
            s.Add("Jules");
            s.Add("Vince");
            s.Add("Stan");
            s.Add("Mathis");
            s.Add("Victor");
            s.Add("Adam");
            s.Add("Alexander");
            s.Add("Leon");
            s.Add("Lewis");
            s.Add("Matteo");
            s.Add("Lars");
            s.Add("Vic");
            s.Add("Mats");
            s.Add("Jack");
            s.Add("Kobe");
            s.Add("Wout");
            s.Add("Lowie");
            s.Add("Tuur");
            s.Add("Oscar");
            s.Add("Felix");
            s.Add("Milan");
            s.Add("Gust");
            s.Add("Emiel");
            s.Add("Mohamed");
            s.Add("Seppe");
            s.Add("Warre");
            s.Add("Rayan");
            s.Add("Jasper");
            s.Add("Thomas");
            s.Add("Jayden");
            s.Add("Cas");
            s.Add("Ferre");
            s.Add("Elias");
            s.Add("Nathan");
            s.Add("Lou");
            s.Add("Viktor");
            s.Add("Lukas");
            s.Add("Daan");
            s.Add("Maurice");
            s.Add("Maxim");
            s.Add("Senne");
            s.Add("Simon");
            s.Add("Marcel");
            s.Add("Luca");
            return s;
        }
        public List<string> getNamen()
        {
            List<string> s = new List<string>();
            s.Add("Van Horen");
            s.Add("Braem");
            s.Add("Van Moorter");
            s.Add("De Vilder");
            s.Add("Peters");
            s.Add("Moens");
            s.Add("Jansens");
            s.Add("Temmerman");
            s.Add("Semal");
            s.Add("Van Dorpe");
            s.Add("Vanbuiten");
            s.Add("Boeikens");
            s.Add("Dekkers");
            s.Add("D'Hondt");
            s.Add("Barbiers");
            s.Add("Dirks");
            s.Add("De Jonge");
            s.Add("Heylen");
            s.Add("Klaasen");
            s.Add("De Graaf");
            s.Add("Van Hasselt");
            s.Add("Goekoop");
            s.Add("De Bruyn");
            s.Add("Cornelis");
            s.Add("Costerus");
            s.Add("De Coster");
            s.Add("Maes");
            s.Add("Mertens");
            s.Add("Mathijssen");
            s.Add("Van der Meer");
            s.Add("de Jaeger");
            s.Add("Mengelberg");
            s.Add("Van Meeuwen");
            s.Add("Van der Meer");
            s.Add("De Boer");
            s.Add("Janssens");
            s.Add("Aalders");
            s.Add("Aelbrecht");
            s.Add("Van Aalst");
            s.Add("Martens");
            s.Add("Van Aecken");
            s.Add("Willems");
            s.Add("Thijs");
            s.Add("Claessens");
            return s;
        }
    }
}