using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projecten2.Models.Domain;
using Projecten2.Models.Domain.KostenVragen;
using Projecten2.Models.ViewModels.BatenViewModels;
using Projecten2.Models.ViewModels.KostenViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Projecten2.Controllers
{
    public class VragenController : Controller
    {
        private readonly IAnalyseRepository _analyseRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public VragenController(
            IAnalyseRepository analyseRepository,
            IApplicationUserRepository userRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _analyseRepository = analyseRepository;
        }

        public IActionResult KVraagS1(int AnalyseId)
        {
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            return View(new KVraagS1ViewModel(analyse.Kosten));
        }
        [HttpPost]
        public IActionResult KVraagS1(KVraagS1ViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Kosten kosten = _analyseRepository.GetById(viewModel.AnalyseId).Kosten;
                    KVraag1_0 vraag = new KVraag1_0(kosten);
                    MapKVraag1_0(viewModel, vraag);
                    kosten.Kvragen01.Add(vraag);
                    _analyseRepository.SaveChanges();
                }
                catch
                {
                    TempData["error"] = "Sorry, something went wrong, the analyse was not edited...";
                }
                return RedirectToAction("KVraagS1Overzicht", "Overzichten", new { viewModel.AnalyseId});
            }
            else
            {
                return View(viewModel);
            }
        }

        //public IActionResult KVraagS2()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult KVraagS2(KVraagS2ViewModel viewModel)
        //{
        //    return View();
        //}

        public IActionResult KVraagS3(int AnalyseId)
        {
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            return View(new KVraagS3ViewModel(analyse.Kosten));
        }
        [HttpPost]
        public IActionResult KVraagS3(KVraagS3ViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Kosten kosten = _analyseRepository.GetById(viewModel.AnalyseId).Kosten;
                    KVraag6 vraag = new KVraag6(kosten);
                    MapKVraag6(viewModel, vraag);
                    kosten.Kvragen6.Add(vraag);
                    _analyseRepository.SaveChanges();
                }
                catch
                {
                    TempData["error"] = "Sorry, something went wrong, the analyse was not edited...";
                }
                return RedirectToAction("KVraagS6Overzicht", "Overzichten", new { viewModel.AnalyseId });
            }
            else
            {
                return View(viewModel);
            }
        }

        public IActionResult KVraagS4(int AnalyseId, int VraagId)
        {
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            KVraagS4ViewModel viewModel = new KVraagS4ViewModel(analyse.Kosten, VraagId);
            switch (VraagId)
            {
                case 2:
                    viewModel.VraagTekst = "Welke kosten moet u ter voorbereiding maken om dit te implementeren?";
                    break;
                case 3:
                    viewModel.VraagTekst = "Welke extra kosten moet u structureel extra maken voor deze inhuur? (alleen kosten zoals werkkleding bij normale inhuur en bij reshoring alle kosten)";
                    break;
                case 4:
                    viewModel.VraagTekst = "Welke kosten moet u structureel jaarlijks extra maken voor deze inhuur? (vul hier de gereedschapskosten ed in)";
                    break;
                case 5:
                    viewModel.VraagTekst = "Welke opleidingskosten moeten er gemaakt worden om de nieuwe kraachten op het gewenste niveau te krijgen?";
                    break;
                case 7:
                    viewModel.VraagTekst = "Aanwelke kosten kan nog meer worden gedacht?";
                    break;
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult KVraagS4(KVraagS4ViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Kosten kosten = _analyseRepository.GetById(viewModel.AnalyseId).Kosten;
                    if (viewModel.VraagId == 2)
                    {
                        KVraag2 vraag = new KVraag2(kosten);
                        MapKVraag2(viewModel, vraag);
                        kosten.Kvragen2.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("KVraagS2Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    else if (viewModel.VraagId == 3)
                    {
                        KVraag3 vraag = new KVraag3(kosten);
                        MapKVraag3(viewModel, vraag);
                        kosten.Kvragen3.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("KVraagS3Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    else if (viewModel.VraagId == 4)
                    {
                        KVraag4 vraag = new KVraag4(kosten);
                        MapKVraag4(viewModel, vraag);
                        kosten.Kvragen4.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("KVraagS4Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    else if (viewModel.VraagId == 5)
                    {
                        KVraag5 vraag = new KVraag5(kosten);
                        MapKVraag5(viewModel, vraag);
                        kosten.Kvragen5.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("KVraagS5Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    else if (viewModel.VraagId == 7)
                    {
                        KVraag7 vraag = new KVraag7(kosten);
                        MapKVraag7(viewModel, vraag);
                        kosten.Kvragen7.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("KVraagS7Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch
                {
                    TempData["error"] = "Sorry, something went wrong, the analyse was not edited...";
                }
            }
            return View(viewModel);
        }

        public IActionResult BVraagS1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BVraagS1(BVraagS1ViewModel viewModel)
        {
            return View();
        }

        public IActionResult BVraagS2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BVraagS2(BVraagS2ViewModel viewModel)
        {
            return View();
        }

        public IActionResult BVraagS3()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BVraagS3(BVraagS3ViewModel viewModel)
        {
            return View();
        }

        public IActionResult BVraagDouble(int AnalyseId, int VraagId)
        {
            // vragen: 2, 7, 8
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            BVraagDoubleViewModel viewModel = new BVraagDoubleViewModel(analyse.Baten, VraagId);
            switch (viewModel.Vraag)
            {
                case 2: viewModel.VraagTekst = "Welk bedrag krijgt u aan subsidie voor eventuele aanpassingen aan de werkomgeving?";
                    viewModel.Bedrag = analyse.Baten.JaarBedSubsWerkOmg; break;
                case 7: viewModel.VraagTekst = "Hoeveel extra productiviteit denkt u te kunnen maken door inzet van mensen met een grote afstand tot de arbeidsmarkt?";
                    viewModel.Bedrag = analyse.Baten.JaarBedExtraProd; break;
                case 8: viewModel.VraagTekst = "Hoeveel denkt u te kunnen besparen op overuren?";
                    viewModel.Bedrag = analyse.Baten.JaarBedOveruren; break;
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult BVraagDouble(BVraagDoubleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Baten baten = _analyseRepository.GetById(viewModel.AnalyseId).Baten;
                    if (viewModel.Vraag == 2)
                    {
                        baten.JaarBedSubsWerkOmg = viewModel.Bedrag;
                    }
                    else if (viewModel.Vraag == 7)
                    {
                        baten.JaarBedExtraProd = viewModel.Bedrag;
                    }
                    else if (viewModel.Vraag == 8)
                    {
                        baten.JaarBedOveruren = viewModel.Bedrag;
                    }
                    else
                    {
                        return NotFound();
                    }
                    _analyseRepository.SaveChanges();
                }
                catch
                {
                    TempData["error"] = "Sorry, something went wrong, the analyse was not edited...";
                }
                return RedirectToAction("KostenBaten", "Analyse", new { id = viewModel.AnalyseId });
            }
            else
            {
                return View(viewModel);
            }
        }

        public IActionResult BVraag6()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BVraag6(BVraag6ViewModel viewModel)
        {
            return View();
        }

        public IActionResult BVraag10()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BVraag10(BVraag10ViewModel viewModel)
        {
            return View();
        }

        private void MapKVraag1_0(KVraagS1ViewModel viewModel, KVraag1_0 vraag)
        {
            vraag.AantalMaandenIBO = viewModel.AantalMaandenIBO;
            vraag.AantalUrenPerWeek = viewModel.AantalUrenPerWeek;
            vraag.BrutoMaandloonFulltime = viewModel.BrutoMaandloonFulltime;
            vraag.Doelgroep = viewModel.Doelgroep;
            vraag.Functie = viewModel.Functie;
            vraag.TotaleProductiviteitsPremie = viewModel.TotaleProductiviteitsPremie;
            vraag.VlaamseOndPremie = viewModel.VlaamseOndPremie;
        }
        private void MapKVraag2(KVraagS4ViewModel viewModel, KVraag2 vraag)
        {
            vraag.Type = viewModel.Vak1;
            vraag.Bedrag = viewModel.Vak2;
        }
        private void MapKVraag3(KVraagS4ViewModel viewModel, KVraag3 vraag)
        {
            vraag.Type = viewModel.Vak1;
            vraag.Bedrag = viewModel.Vak2;
        }
        private void MapKVraag4(KVraagS4ViewModel viewModel, KVraag4 vraag)
        {
            vraag.Type = viewModel.Vak1;
            vraag.Bedrag = viewModel.Vak2;
        }
        private void MapKVraag5(KVraagS4ViewModel viewModel, KVraag5 vraag)
        {
            vraag.Type = viewModel.Vak1;
            vraag.Bedrag = viewModel.Vak2;
        }
        private void MapKVraag6(KVraagS3ViewModel viewModel, KVraag6 vraag)
        {
            vraag.Uren = viewModel.Vak1;
            vraag.BrutoMaandloonBegeleider = viewModel.Vak2;
        }
        private void MapKVraag7(KVraagS4ViewModel viewModel, KVraag7 vraag)
        {
            vraag.Type = viewModel.Vak1;
            vraag.Bedrag = viewModel.Vak2;
        }
    }
}

// --- Voorbeeld voor een vraag ---

//public IActionResult BVraag2(int id)
//{
//    Analyse analyse = _analyseRepository.GetById(id);
//    Baten baten = _batenRepository.GetById(analyse.Baten.BatenId);
//    return View(new BVraagDoubleViewModel(baten, 2));
//}

//[HttpPost]
//public IActionResult BVraag2(BVraagDoubleViewModel viewModel)
//{
//    if (ModelState.IsValid)
//    {
//        Baten baten = null;
//        try
//        {
//            baten = _batenRepository.GetByAnalyse(viewModel.AnalyseId);
//            MapJaarBedSubsWerkOmgViewModelToBaten(viewModel, baten);
//            _analyseRepository.SaveChanges();
//        }
//        catch
//        {
//            TempData["error"] = "Sorry, something went wrong, the analyse was not edited...";
//        }
//        return RedirectToAction("KostenBaten", new { id = viewModel.AnalyseId });
//    }
//    else
//    {
//        return View(viewModel);
//    }
//}
