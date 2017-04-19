using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projecten2.Models.Domain;
using Projecten2.Models.ViewModels.BatenViewModels;
using Projecten2.Models.ViewModels.KostenViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Projecten2.Controllers
{
    public class VragenController : Controller
    {
        private readonly IBatenRepository _batenRepository;
        private readonly IKostenRepository _kostenRepository;
        private readonly IAnalyseRepository _analyseRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public VragenController(
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

        public IActionResult KVraagS1(int AnalyseId)
        {
            //    Analyse analyse = _analyseRepository.GetById(id);
            //    Baten baten = _batenRepository.GetById(analyse.Baten.BatenId);
            //    return View(new BVraagDoubleViewModel(baten, 2));
            Analyse analyse = _analyseRepository.GetById(AnalyseId);
            return View(new KVraagS1ViewModel(analyse.Kosten));
        }
        [HttpPost]
        public IActionResult KVraagS1(KVraagS1ViewModel viewModel)
        {
            return View();
        }

        public IActionResult KVraagS2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KVraagS2(KVraagS2ViewModel viewModel)
        {
            return View();
        }

        public IActionResult KVraagS3()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KVraagS3(KVraagS3ViewModel viewModel)
        {
            return View();
        }

        public IActionResult KVraagS4()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KVraagS4(KVraagS4ViewModel viewModel)
        {
            return View();
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

        public IActionResult BVraagDouble()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BVraagDouble(BVraagDoubleViewModel viewModel)
        {
            return View();
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
