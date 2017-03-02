using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projecten2.Models.Domain;
using Projecten2.Models.ViewModels;

namespace Projecten2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnalyseRepository _analyseRepository;

        public HomeController(IAnalyseRepository analyseRepository)
        {
            _analyseRepository = analyseRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Analyse> analyses = _analyseRepository.GetAll().Where(a => !a.archief).OrderBy(a => a.datum).ToList();
            return View(analyses);
        }
        
        public IActionResult Archiveer(int id)
        {
            Analyse analyse = null;
            try
            {
                analyse = _analyseRepository.GetById(id);
                _analyseRepository.ArchiveerAnalyse(analyse);
                _analyseRepository.SaveChanges();
                TempData["message"] = $"You successfully archived analyse {analyse.naam}.";
            } catch {
                TempData["error"] = $"Sorry, something went wrong, analyse {analyse.naam} was not archived.";
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Archief()
        {
            IEnumerable<Analyse> analyses = _analyseRepository.GetAll().Where(a => a.archief).OrderBy(a => a.datum).ToList();
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
    }
}
