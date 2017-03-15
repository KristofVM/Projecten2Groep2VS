using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projecten2.Models.Domain;
using Projecten2.Models.ViewModels;

namespace Projecten2.Controllers
{
    public class AnalyseController : Controller
    {
        private readonly IAnalyseRepository _analyseRepository;
        private readonly IApplicationUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnalyseController(
            IAnalyseRepository analyseRepository,
            IApplicationUserRepository userRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _analyseRepository = analyseRepository;
            _userRepository = userRepository;
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
            return RedirectToAction(nameof(Index),"Home");
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
            return RedirectToAction(nameof(Index),"Home");
        }

        public IActionResult KostenBaten()
        {
            return View();
        }

        private void MapEditViewModelToAnalyse(EditViewModel editViewModel, Analyse analyse)
        {
            analyse.ApplicationUserId = _userManager.GetUserId(User);
            analyse.Naam = editViewModel.Naam;
            analyse.Bedrijf = editViewModel.Bedrijf;
            analyse.Afdeling = editViewModel.Afdeling;
            analyse.PatronaleBijdrage = editViewModel.PatronaleBijdrage;
            analyse.UrenVoltijdsWerkweek = editViewModel.UrenVoltijdsWerkweek;
        }
    }
}