using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projecten2.Models.Domain;
using Projecten2.Models.ViewModels;
using Projecten2.Models.ViewModels.BatenViewModels;

namespace Projecten2.Controllers
{
    public class AnalyseController : Controller
    {
        private readonly IBatenRepository _batenRepository;
        private readonly IAnalyseRepository _analyseRepository;
        private readonly IApplicationUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnalyseController(
            IBatenRepository batenRepository,
            IAnalyseRepository analyseRepository,
            IApplicationUserRepository userRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _batenRepository = batenRepository;
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
            if (ModelState.IsValid)
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
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                return View(editViewModel);
            }
        }

        public IActionResult Create()
        {
            return View(nameof(Edit), new EditViewModel(new Analyse()));
        }

        [HttpPost]
        public IActionResult Create(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
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
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                return View(nameof(Edit),editViewModel);
            }
        }

        public IActionResult KostenBaten(int id)
        {
            Analyse analyse = _analyseRepository.GetById(id);
            return View(analyse);
        }

        public IActionResult BVraag2(int id)
        {
            Analyse analyse = _analyseRepository.GetById(id);
            Baten baten = _batenRepository.GetById(analyse.Baten.BatenId);
            return View(new JaarBedSubsWerkOmgViewModel(baten));
        }

        [HttpPost]
        public IActionResult BVraag2(JaarBedSubsWerkOmgViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Baten baten = null;
                try
                {
                    baten = _batenRepository.GetByAnalyse(viewModel.AnalyseId);
                    MapJaarBedSubsWerkOmgViewModelToBaten(viewModel, baten);
                    _analyseRepository.SaveChanges();
                }
                catch
                {
                    TempData["error"] = "Sorry, something went wrong, the analyse was not edited...";
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                return View(viewModel);
            }
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
        private void MapJaarBedSubsWerkOmgViewModelToBaten(JaarBedSubsWerkOmgViewModel viewModel, Baten baten)
        {
            baten.JaarBedSubsWerkOmg = viewModel.Bedrag;
        }
    }
}