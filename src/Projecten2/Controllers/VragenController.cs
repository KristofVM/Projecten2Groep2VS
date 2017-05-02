using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projecten2.Data.Repositories;
using Projecten2.Models.Domain;
using Projecten2.Models.Domain.BatenVragen;
using Projecten2.Models.Domain.KostenVragen;
using Projecten2.Models.ViewModels.BatenViewModels;
using Projecten2.Models.ViewModels.KostenViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Projecten2.Controllers
{
    public class VragenController : Controller
    {
        private readonly IAnalyseRepository _analyseRepository;
        private readonly IDoelgroepRepository _doelgroepRepository;

        public VragenController(
            IAnalyseRepository analyseRepository,
            IDoelgroepRepository doelgroepRepository)
        {
            _analyseRepository = analyseRepository;
            _doelgroepRepository = doelgroepRepository;
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
            return View(viewModel);
        }

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
            return View(viewModel);
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
                    viewModel.VraagTekst = "Welke opleidingskosten moeten er gemaakt worden om de nieuwe krachten op het gewenste niveau te krijgen?";
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
                    if (viewModel.VraagId == 3)
                    {
                        KVraag3 vraag = new KVraag3(kosten);
                        MapKVraag3(viewModel, vraag);
                        kosten.Kvragen3.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("KVraagS3Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    if (viewModel.VraagId == 4)
                    {
                        KVraag4 vraag = new KVraag4(kosten);
                        MapKVraag4(viewModel, vraag);
                        kosten.Kvragen4.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("KVraagS4Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    if (viewModel.VraagId == 5)
                    {
                        KVraag5 vraag = new KVraag5(kosten);
                        MapKVraag5(viewModel, vraag);
                        kosten.Kvragen5.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("KVraagS5Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    if (viewModel.VraagId == 7)
                    {
                        KVraag7 vraag = new KVraag7(kosten);
                        MapKVraag7(viewModel, vraag);
                        kosten.Kvragen7.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("KVraagS7Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    return NotFound();
                }
                catch
                {
                    TempData["error"] = "Sorry, something went wrong, the analyse was not edited...";
                }
            }
            return View(viewModel);
        }

        public IActionResult BVraagS1(int AnalyseId, int VraagId)
        {
            // Vraag 5, 9
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            BVraagS1ViewModel viewModel = new BVraagS1ViewModel(analyse.Baten, VraagId);
            switch (VraagId)
            {
                case 5:
                    viewModel.VraagTekst = "Welke besparing denkt u te kunnen maken op uitzendkrachten?";
                    break;
                case 9:
                    viewModel.VraagTekst = "Welke zaken worden extern ingekocht en kan op worden bespaard? Denk hierbij aan bijvoorbeeld uitbesteedde productie, schoonmaak, hoveniers enz.";
                    break;
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult BVraagS1(BVraagS1ViewModel viewModel)
        {
            // Vraag 5, 9
            if (ModelState.IsValid)
            {
                try
                {
                    Baten baten = _analyseRepository.GetById(viewModel.AnalyseId).Baten;
                    if (viewModel.VraagId == 5)
                    {
                        BVraag5 vraag = new BVraag5(baten);
                        MapBVraag5(viewModel, vraag);
                        baten.Bvragen5.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("BVraagS5Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    if (viewModel.VraagId == 9)
                    {
                        BVraag9 vraag = new BVraag9(baten);
                        MapBVraag9(viewModel, vraag);
                        baten.Bvragen9.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("BVraagS9Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    return NotFound();
                }
                catch
                {
                    TempData["error"] = "Sorry, something went wrong, the analyse was not edited...";
                }
            }
            return View(viewModel);
        }

        public IActionResult BVraagS2(int AnalyseId, int VraagId)
        {
            // Vraag 3, 4
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            BVraagS2ViewModel viewModel = new BVraagS2ViewModel(analyse.Baten, VraagId);
            switch (viewModel.VraagId)
            {
                case 3:
                    viewModel.VraagTekst = "Vul hier de lonen op hetzelfde niveau in die mogelijk vervangen worden, met het geschatte aantal uren dat per week weggehaald wordt.";
                    break;
                case 4:
                    viewModel.VraagTekst = "Vul hier de lonen op een hoger niveau in die mogelijk vervangen worden, met het geschatte aantal uren dat per week weggehaald wordt.";
                    break;
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult BVraagS2(BVraagS2ViewModel viewModel)
        {
            // Vraag 3, 4
            if (ModelState.IsValid)
            {
                try
                {
                    Baten baten = _analyseRepository.GetById(viewModel.AnalyseId).Baten;
                    if (viewModel.VraagId == 3)
                    {
                        BVraag3 vraag = new BVraag3(baten);
                        MapBVraag3(viewModel, vraag);
                        baten.Bvragen3.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("BVraagS3Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    if (viewModel.VraagId == 4)
                    {
                        BVraag4 vraag = new BVraag4(baten);
                        MapBVraag4(viewModel, vraag);
                        baten.Bvragen4.Add(vraag);
                        _analyseRepository.SaveChanges();
                        return RedirectToAction("BVraagS4Overzicht", "Overzichten", new { viewModel.AnalyseId });
                    }
                    return NotFound();
                }
                catch
                {
                    TempData["error"] = "Sorry, something went wrong, the analyse was not edited...";
                }
            }
            return View(viewModel);
        }

        public IActionResult BVraagS3(int AnalyseId)
        {
            // Vraag 11
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            BVraagS3ViewModel viewModel = new BVraagS3ViewModel(analyse.Baten);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult BVraagS3(BVraagS3ViewModel viewModel)
        {
            // Vraag 11
            if (ModelState.IsValid)
            {
                try
                {
                    Baten baten = _analyseRepository.GetById(viewModel.AnalyseId).Baten;
                    BVraag11 vraag = new BVraag11(baten);
                    vraag.TypeBesparing = viewModel.Vak1;
                    vraag.JaarBedrag = viewModel.Vak2;
                    baten.Bvragen11.Add(vraag);
                    _analyseRepository.SaveChanges();
                }
                catch
                {
                    TempData["error"] = "Sorry, something went wrong, the analyse was not edited...";
                }
                return RedirectToAction("BVraagS11Overzicht", "Overzichten", new { viewModel.AnalyseId });
            }
            return View(viewModel);
        }

        public IActionResult BVraagDouble(int AnalyseId, int VraagId)
        {
            // vragen: 2, 7, 8
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            BVraagDoubleViewModel viewModel = new BVraagDoubleViewModel(analyse.Baten, VraagId);
            switch (viewModel.VraagId)
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
                    if (viewModel.VraagId == 2)
                    {
                        baten.JaarBedSubsWerkOmg = viewModel.Bedrag;
                    }
                    else if (viewModel.VraagId == 7)
                    {
                        baten.JaarBedExtraProd = viewModel.Bedrag;
                    }
                    else if (viewModel.VraagId == 8)
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
            return View(viewModel);
        }

        public IActionResult BVraag6(int AnalyseId)
        {
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            BVraag6ViewModel viewModel = new BVraag6ViewModel(analyse.Baten);
            viewModel.Vak1 = analyse.Baten.JaarBedOmzetVerlies;
            viewModel.Vak2 = analyse.Baten.ProcentBesparing;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult BVraag6(BVraag6ViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Baten baten = _analyseRepository.GetById(viewModel.AnalyseId).Baten;
                    baten.JaarBedOmzetVerlies = viewModel.Vak1;
                    baten.ProcentBesparing = viewModel.Vak2;
                    _analyseRepository.SaveChanges();
                }
                catch
                {
                    TempData["error"] = "Sorry, something went wrong, the analyse was not edited...";
                }
                return RedirectToAction("KostenBaten", "Analyse", new { id = viewModel.AnalyseId });
            }
            return View(viewModel);
        }

        public IActionResult BVraag10(int AnalyseId)
        {
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            BVraag10ViewModel viewModel = new BVraag10ViewModel(analyse.Baten);
            viewModel.Vak1 = analyse.Baten.JaarBedTransportKost;
            viewModel.Vak2 = analyse.Baten.JaarBedHandelingsKost;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult BVraag10(BVraag10ViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Baten baten = _analyseRepository.GetById(viewModel.AnalyseId).Baten;
                    baten.JaarBedTransportKost = viewModel.Vak1;
                    baten.JaarBedHandelingsKost = viewModel.Vak2;
                    _analyseRepository.SaveChanges();
                }
                catch
                {
                    TempData["error"] = "Sorry, something went wrong, the analyse was not edited...";
                }
                return RedirectToAction("KostenBaten", "Analyse", new { id = viewModel.AnalyseId });
            }
            return View(viewModel);
        }

        private void MapKVraag1_0(KVraagS1ViewModel viewModel, KVraag1_0 vraag)
        {
            vraag.AantalMaandenIBO = viewModel.AantalMaandenIBO;
            vraag.AantalUrenPerWeek = viewModel.AantalUrenPerWeek;
            vraag.BrutoMaandloonFulltime = viewModel.BrutoMaandloonFulltime;
            vraag.Doelgroep = _doelgroepRepository.GetById(viewModel.Doelgroep);
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

        private void MapBVraag3(BVraagS2ViewModel viewModel, BVraag3 vraag)
        {
            vraag.Uren = viewModel.Vak1;
            vraag.BrutoMaandloonFulltime = viewModel.Vak2;
        }
        private void MapBVraag4(BVraagS2ViewModel viewModel, BVraag4 vraag)
        {
            vraag.Uren = viewModel.Vak1;
            vraag.BrutoMaandloonFulltime = viewModel.Vak2;
        }
        private void MapBVraag5(BVraagS1ViewModel viewModel, BVraag5 vraag)
        {
            vraag.Beschrijving = viewModel.Vak1;
            vraag.JaarBedrag = viewModel.Vak2;
        }
        private void MapBVraag9(BVraagS1ViewModel viewModel, BVraag9 vraag)
        {
            vraag.Beschrijving = viewModel.Vak1;
            vraag.JaarBedrag = viewModel.Vak2;
        }
    }
}
