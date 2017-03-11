using System;
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
            IEnumerable<Analyse> analyses = _analyseRepository.GetAll()
                .Where(a => !a.Archief && a.ApplicationUserId == userInfo)
                .OrderBy(a => a.Datum)
                .ToList();
            return View(analyses);
        }

        public IActionResult Archief()
        {
            string userInfo = _userManager.GetUserId(User);
            IEnumerable<Analyse> analyses = _analyseRepository.GetAll()
                .Where(a => a.Archief && a.ApplicationUserId == userInfo)
                .OrderBy(a => a.Datum)
                .ToList();
            return View(analyses);
        }

        public IActionResult Edit(int id)
        {
            Analyse analyse = _analyseRepository.GetById(id);
            return View(new EditViewModel(analyse));
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel editViewModel)
        {
            Analyse analyse = null;
            try
            {
                analyse = _analyseRepository.GetById(editViewModel.AnalyseId);
                MapEditViewModelToAnalyse(editViewModel, analyse);
                _analyseRepository.SaveChanges();
                TempData["message"] = $"You successfully updated brewer {analyse.Naam}.";
            }
            catch
            {
                TempData["error"] = $"Sorry, something went wrong, brewer {analyse?.Naam} was not updated...";
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View(nameof(Edit), new EditViewModel(new Analyse()));
        }

        [HttpPost]
        public IActionResult Create(EditViewModel editViewModel)
        {
            Analyse analyse = new Analyse();
            try
            {
                MapEditViewModelToAnalyse(editViewModel, analyse);
                _analyseRepository.Add(analyse);
                _analyseRepository.SaveChanges();
                TempData["message"] = $"You successfully added brewer {analyse.Naam}.";
            }
            catch
            {
                TempData["error"] = "Sorry, something went wrong, the analyse was not added...";
            }
            return RedirectToAction(nameof(Index));
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
                TempData["message"] = $"You successfully archived analyse {analyse.Naam}.";
            }
            catch
            {
                TempData["error"] = $"Sorry, something went wrong, analyse {analyse.Naam} was not archived.";
            }
            return RedirectToAction(nameof(Index));
        }

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
                    TempData["message"] = $"You successfully unarchived analyse {analyse.Naam}.";
                }
                catch
                {
                    TempData["error"] = $"Sorry, something went wrong, analyse {analyse.Naam} was not unarchived.";
                }
            }
            return RedirectToAction(nameof(Archief));
        }

        private void MapEditViewModelToAnalyse(EditViewModel editViewModel, Analyse analyse)
        {
            analyse.ApplicationUserId = _userManager.GetUserId(User);
            analyse.Naam = editViewModel.Naam;
            analyse.Bedrijf = editViewModel.Bedrijf;
            analyse.Afdeling = editViewModel.Afdeling;
        }
    }
}
