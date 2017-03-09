﻿using System;
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

        public HomeController(IAnalyseRepository analyseRepository, IApplicationUserRepository userRepository)
        {
            _analyseRepository = analyseRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            string userInfo = _userManager.GetUserName(User);
            ApplicationUser user = _userRepository.GetByEmail(userInfo);
            return View(user);
            //IEnumerable<Analyse> analyses = _analyseRepository.GetAll().Where(a => !a.Archief).OrderBy(a => a.Datum).ToList();
            //return View(analyses);
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
            } catch {
                TempData["error"] = $"Sorry, something went wrong, analyse {analyse.Naam} was not archived.";
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Archief()
        {
            IEnumerable<Analyse> analyses = _analyseRepository.GetAll().Where(a => a.Archief).OrderBy(a => a.Datum).ToList();
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
