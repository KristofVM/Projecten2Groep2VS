using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Projecten2.Data;
using Projecten2.Models.AccountViewModels;
using Projecten2.Models.Domain;
using Projecten2.Models.ViewModels;
using Projecten2.Services;

namespace Projecten2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnalyseRepository _analyseRepository;
        private readonly IApplicationUserRepository _userRepository;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(
            IAnalyseRepository analyseRepository,
            IApplicationUserRepository userRepository,
            IEmailSender emailSender,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _analyseRepository = analyseRepository;
            _emailSender = emailSender;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            string userId = _userManager.GetUserId(User);
            ApplicationUser user = _userRepository.GetById(userId);
            IEnumerable<Analyse> analyses = new List<Analyse>();
            if (user != null)
            {
                analyses = user.Analyses.Where(a => !a.Archief);
                return View(analyses);
            } 
            return View(analyses);
        }

        public IActionResult Archief()
        {
            IEnumerable<Analyse> analyses = new List<Analyse>();
            var userInfo = _userManager.GetUserId(User);
            var appUser = _userRepository.GetById(userInfo);
            if (appUser != null)
                analyses = appUser.Analyses.Where(a => a.Archief);
            return View(analyses);
        }

        [HttpPost]
        public IActionResult Archief(string zoektekst)
        {
            if (zoektekst == null)
            {
                return RedirectToAction(nameof(Archief));
            }
            IEnumerable<Analyse> analyses = new List<Analyse>();
            var userInfo = _userManager.GetUserId(User);
            var appUser = _userRepository.GetById(userInfo);
            if (appUser != null)
                analyses = appUser.Analyses.Where(a => a.Archief).Where(a => a.Bedrijf.Contains(zoektekst.ToLower()));
            return View(analyses);
        }

        public IActionResult Faq()
        {
            ViewData["Message"] = "Not implemented yet.";
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string userId = _userManager.GetUserId(User);
                ApplicationUser user = _userRepository.GetById(userId);
                string tekst = user.Voornaam + " " + user.Naam + "\n" +
                    user.Organisatie + "\n" +
                    user.Email + "\n" +
                    user.Straat + " " + user.Nr + " " + user.Bus + "\n" +
                    user.Postcode + " " + user.Plaats + "\n" 
                    + viewModel.Bericht;
                await _emailSender.SendEmailAsync("crypt0c0d3@gmail.com", viewModel.Onderwerp, tekst);
                TempData["Message"] = "Je email is verzonden.";
                return RedirectToAction("Contact");
            }
            return View();
        }

        public IActionResult Profiel()
        {
            string userId = _userManager.GetUserId(User);
            ApplicationUser user = _userRepository.GetById(userId);
            return View(new RegisterViewModel()
            {
                Bus = user.Bus,
                Naam = user.Naam,
                Voornaam = user.Voornaam,
                Email = user.Email,
                Plaats = user.Plaats,
                Organisatie = user.Organisatie,
                Nr = user.Nr,
                Straat = user.Straat,
                Postcode = user.Postcode});
        }

        [HttpPost]
        public IActionResult Profiel(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string userId = _userManager.GetUserId(User);
                ApplicationUser user = _userRepository.GetById(userId);
                user.Naam = viewModel.Naam;
                user.Voornaam = viewModel.Voornaam;
                user.Nr = viewModel.Nr;
                user.Bus = viewModel.Bus;
                user.Straat = viewModel.Straat;
                user.Plaats = viewModel.Plaats;
                user.Postcode = viewModel.Postcode;
                user.Organisatie = viewModel.Organisatie;
                _userRepository.SaveChanges();
                TempData["Message"] = "Je gegevens zijn aangepast.";
                return View();
            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        
        public IActionResult Archiveer(int id)
        {
            Analyse analyse = null;
            try
            {
                analyse = _analyseRepository.GetById(id);
                _analyseRepository.ArchiveerAnalyse(analyse);
                _analyseRepository.SaveChanges();
                TempData["message"] = $"You successfully archived analyse {analyse.Bedrijf}.";
            }
            catch
            {
                TempData["error"] = $"Sorry, something went wrong, analyse {analyse.Bedrijf} was not archived.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeArchiveer(int[] selectanalyse)
        {
            Analyse analyse = null;
            foreach (int id in selectanalyse)
            {
                try
                {
                    analyse = _analyseRepository.GetById(id);
                    _analyseRepository.DeArchiveerAnalyse(analyse);
                    _analyseRepository.SaveChanges();
                    TempData["message"] = $"You successfully unarchived analyse {analyse.Bedrijf}.";
                }
                catch
                {
                    TempData["error"] = $"Sorry, something went wrong, analyse {analyse.Bedrijf} was not unarchived.";
                }
            }
            return RedirectToAction(nameof(Archief));
        }
    }
}
