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
        private readonly IKostenRepository _kostenRepository;
        private readonly IAnalyseRepository _analyseRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnalyseController(
            IBatenRepository batenRepository,
            IKostenRepository kostenRepository,
            IAnalyseRepository analyseRepository,
            IApplicationUserRepository userRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _batenRepository = batenRepository;
            _kostenRepository = kostenRepository;
            _analyseRepository = analyseRepository;
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

        public IActionResult BVraag(int AnalyseId, int VraagId)
        {
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            Baten baten = _batenRepository.GetById(analyse.Baten.BatenId);
            switch (VraagId)
            {
                case 2: return RedirectToAction("BVraagDouble", "Vragen", new { AnalyseId, VraagId });
                case 3: return RedirectToAction("BVraagS2", "Vragen", new {AnalyseId, VraagId});
                case 4: return RedirectToAction("BVraagS2", "Vragen", new { AnalyseId, VraagId });
                case 5: return RedirectToAction("BVraagS1", "Vragen", new { AnalyseId, VraagId });
                //case 6: return RedirectToAction("BVraagInt", "Vragen", new { AnalyseId });
                case 6: return RedirectToAction("BVraag6", "Vragen", new { AnalyseId });
                case 7: return RedirectToAction("BVraagDouble", "Vragen", new { AnalyseId, VraagId });
                case 8: return RedirectToAction("BVraagDouble", "Vragen", new { AnalyseId, VraagId });
                case 9: return RedirectToAction("BVraagS1", "Vragen", new { AnalyseId, VraagId });
                //case 101: return RedirectToAction("BVraagDouble", "Vragen", new { AnalyseId, VraagId });
                //case 102: return RedirectToAction("BVraagDouble", "Vragen", new { AnalyseId, VraagId });
                case 10: return RedirectToAction("BVraag10", "Vragen", new { AnalyseId, VraagId });
                case 11: return RedirectToAction("BVraagS3", "Vragen", new { AnalyseId });
                default: return NotFound();
            }
        }
        public IActionResult KVraag(int AnalyseId, int VraagId)
        {
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            Kosten kosten = _kostenRepository.GetById(analyse.Kosten.KostenId);
            switch (VraagId)
            {
                case 1: return RedirectToAction("KVraagS1", "Vragen", new { AnalyseId });
                //case 11: return RedirectToAction("KVraagS2", "Vragen", new { AnalyseId });
                case 2: return RedirectToAction("KVraagS4", "Vragen", new {AnalyseId, VraagId});
                case 3: return RedirectToAction("KVraagS4", "Vragen", new { AnalyseId, VraagId });
                case 4: return RedirectToAction("KVraagS4", "Vragen", new { AnalyseId, VraagId });
                case 5: return RedirectToAction("KVraagS4", "Vragen", new { AnalyseId, VraagId });
                case 6: return RedirectToAction("KVraagS3", "Vragen", new { AnalyseId });
                case 7: return RedirectToAction("KVraagS4", "Vragen", new { AnalyseId, VraagId });
                default: return NotFound();
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
    }
}