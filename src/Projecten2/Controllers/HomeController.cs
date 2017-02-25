using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projecten2.Models.Domain;

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
            IEnumerable<Analyse> analyses = _analyseRepository.GetAll().OrderBy(a => a.datum).ToList();
            return View(analyses);
        }

        public IActionResult Archief()
        {
            return View();
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
