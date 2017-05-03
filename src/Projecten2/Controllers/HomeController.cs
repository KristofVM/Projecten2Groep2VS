using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Projecten2.Data;
using Projecten2.Models.Domain;
using Projecten2.Models.ViewModels;

namespace Projecten2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnalyseRepository _analyseRepository;
        private readonly IApplicationUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(
            IAnalyseRepository analyseRepository,
            IApplicationUserRepository userRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _analyseRepository = analyseRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            string userInfo = _userManager.GetUserId(User);
            ApplicationUser appUser = _userRepository.GetById(userInfo);
            IEnumerable<Analyse> analyses = new List<Analyse>();
            if (appUser != null)
            {
                analyses = appUser.Analyses.Where(a => !a.Archief);
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
            ViewData["Message"] = "Not implemented yet.";
            return View();
        }

        public IActionResult Profiel()
        {
            ViewData["Message"] = "Not implemented yet.";
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
