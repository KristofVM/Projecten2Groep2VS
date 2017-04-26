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

                ICollection<Analyse> analysen = new List<Analyse>();
                
                Analyse analyse1 = new Analyse();
                analyse1.Afdeling = "kuisdienst";
                analyse1.Bedrijf = "google";
                analyse1.Datum = new DateTime(2017, 3, 25);
                analyse1.Balans = 0;
                analyse1.Archief = false;
                analysen.Add(analyse1);

                Analyse analyse2 = new Analyse();
                analyse2.Afdeling = "advertising";
                analyse2.Bedrijf = "tuc";
                analyse2.Datum = new DateTime(2016, 1, 10);
                analyse2.Balans = -3500;
                analyse2.Archief = false;
                analysen.Add(analyse2);

                Analyse analyse3 = new Analyse();
                analyse3.Afdeling = "production";
                analyse3.Bedrijf = "apple";
                analyse3.Datum = new DateTime(2014, 9, 13);
                analyse3.Balans = 50000;
                analyse3.Archief = false;
                analysen.Add(analyse3);

                Analyse analyse4 = new Analyse();
                analyse4.Afdeling = "retail";
                analyse4.Bedrijf = "action";
                analyse4.Datum = new DateTime(2014, 9, 13);
                analyse4.Balans = 1256960;
                analyse4.Archief = true;
                analysen.Add(analyse4);

                Analyse analyse5 = new Analyse();
                analyse5.Afdeling = "production";
                analyse5.Bedrijf = "gabriëls";
                analyse5.Datum = new DateTime(2012, 1, 20);
                analyse5.Balans = 2500;
                analyse5.Archief = true;
                analysen.Add(analyse5);

                Analyse analyse6 = new Analyse();
                analyse6.Afdeling = "store";
                analyse6.Bedrijf = "colruyt";
                analyse6.Datum = new DateTime(2013, 9, 13);
                analyse6.Balans = 30064;
                analyse6.Archief = true;
                analysen.Add(analyse6);

                Analyse analyse7 = new Analyse();
                analyse7.Afdeling = "lobby";
                analyse7.Bedrijf = "hotel de paris";
                analyse7.Datum = new DateTime(1997, 10, 27);
                analyse7.Balans = -14750;
                analyse7.Archief = true;
                analysen.Add(analyse7);

                Analyse analyse8 = new Analyse();
                analyse8.Afdeling = "management";
                analyse8.Bedrijf = "belfius";
                analyse8.Datum = new DateTime(2015, 6, 30);
                analyse8.Balans = 3560000;
                analyse8.Archief = true;
                analysen.Add(analyse8);

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
    }
}