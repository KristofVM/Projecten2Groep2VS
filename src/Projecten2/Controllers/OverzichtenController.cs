using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projecten2.Models.Domain;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Projecten2.Controllers
{
    public class OverzichtenController : Controller
    {
        private readonly IAnalyseRepository _analyseRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public OverzichtenController(
            IAnalyseRepository analyseRepository,
            IApplicationUserRepository userRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _analyseRepository = analyseRepository;
        }

        public IActionResult KVraagS1Overzicht(int AnalyseId)
        {
            return View(_analyseRepository.GetById(AnalyseId));
        }
        public IActionResult KVraagS2Overzicht(int AnalyseId)
        {
            return View(_analyseRepository.GetById(AnalyseId));
        }
        public IActionResult KVraagS3Overzicht(int AnalyseId)
        {
            return View(_analyseRepository.GetById(AnalyseId));
        }
        public IActionResult KVraagS4Overzicht(int AnalyseId)
        {
            return View(_analyseRepository.GetById(AnalyseId));
        }
        public IActionResult KVraagS5Overzicht(int AnalyseId)
        {
            return View(_analyseRepository.GetById(AnalyseId));
        }
        public IActionResult KVraagS6Overzicht(int AnalyseId)
        {
            return View(_analyseRepository.GetById(AnalyseId));
        }
        public IActionResult KVraagS7Overzicht(int AnalyseId)
        {
            return View(_analyseRepository.GetById(AnalyseId));
        }
        public IActionResult BVraagS3Overzicht(int AnalyseId)
        {
            return View(_analyseRepository.GetById(AnalyseId));
        }
        public IActionResult BVraagS4Overzicht(int AnalyseId)
        {
            return View(_analyseRepository.GetById(AnalyseId));
        }
        public IActionResult BVraagS5Overzicht(int AnalyseId)
        {
            return View(_analyseRepository.GetById(AnalyseId));
        }
        public IActionResult BVraagS9Overzicht(int AnalyseId)
        {
            return View(_analyseRepository.GetById(AnalyseId));
        }
        public IActionResult BVraagS11Overzicht(int AnalyseId)
        {
            return View(_analyseRepository.GetById(AnalyseId));
        }

        public IActionResult VerwijderBVraag(int AnalyseId, int VraagId, int VraagNr)
        {
            Analyse analyse = null;
            try
            {
                analyse = _analyseRepository.GetById(AnalyseId);
                if (VraagNr == 3)
                {
                    analyse.Baten
                        .Bvragen3
                        .Remove(analyse
                            .Baten
                            .Bvragen3
                            .FirstOrDefault(a => a.Id.Equals(VraagId))
                            );
                    _analyseRepository.SaveChanges();
                    return RedirectToAction("BVraagS3Overzicht", new { AnalyseId });
                }
                if (VraagNr == 4)
                {
                    analyse.Baten
                        .Bvragen4
                        .Remove(analyse
                            .Baten
                            .Bvragen4
                            .FirstOrDefault(a => a.Id.Equals(VraagId))
                            );
                    _analyseRepository.SaveChanges();
                    return RedirectToAction("BVraagS4Overzicht", new { AnalyseId });
                }
                if (VraagNr == 5)
                {
                    analyse.Baten
                        .Bvragen5
                        .Remove(analyse
                            .Baten
                            .Bvragen5
                            .FirstOrDefault(a => a.Id.Equals(VraagId))
                            );
                    _analyseRepository.SaveChanges();
                    return RedirectToAction("BVraagS5Overzicht", new { AnalyseId });
                }
                if (VraagNr == 9)
                {
                    analyse.Baten
                        .Bvragen9
                        .Remove(analyse
                            .Baten
                            .Bvragen9
                            .FirstOrDefault(a => a.Id.Equals(VraagId))
                            );
                    _analyseRepository.SaveChanges();
                    return RedirectToAction("BVraagS9Overzicht", new { AnalyseId });
                }
                if (VraagNr == 11)
                {
                    analyse.Baten
                        .Bvragen11
                        .Remove(analyse
                            .Baten
                            .Bvragen11
                            .FirstOrDefault(a => a.Id.Equals(VraagId))
                            );
                    _analyseRepository.SaveChanges();
                    return RedirectToAction("BVraagS11Overzicht", new { AnalyseId });
                }
            }
            catch
            {
                TempData["error"] = $"Sorry, something went wrong.";
            }
            return NotFound();
        }

        public IActionResult VerwijderKVraag(int AnalyseId, int VraagId, int VraagNr)
        {
            Analyse analyse = null;
            try
            {
                analyse = _analyseRepository.GetById(AnalyseId);
                if (VraagNr == 1)
                {
                    analyse.Kosten
                        .Kvragen01
                        .Remove(analyse
                            .Kosten
                            .Kvragen01
                            .FirstOrDefault(a => a.Id.Equals(VraagId))
                            );
                    _analyseRepository.SaveChanges();
                    return RedirectToAction("KVraagS1Overzicht", new { AnalyseId });
                }
                if (VraagNr == 2)
                {
                    analyse.Kosten
                        .Kvragen2
                        .Remove(analyse
                            .Kosten
                            .Kvragen2
                            .FirstOrDefault(a => a.Id.Equals(VraagId))
                            );
                    _analyseRepository.SaveChanges();
                    return RedirectToAction("KVraagS2Overzicht", new { AnalyseId });
                }
                if (VraagNr == 3)
                {
                    analyse.Kosten
                        .Kvragen3
                        .Remove(analyse
                            .Kosten
                            .Kvragen3
                            .FirstOrDefault(a => a.Id.Equals(VraagId))
                            );
                    _analyseRepository.SaveChanges();
                    return RedirectToAction("KVraagS3Overzicht", new { AnalyseId });
                }
                if (VraagNr == 4)
                {
                    analyse.Kosten
                        .Kvragen4
                        .Remove(analyse
                            .Kosten
                            .Kvragen4
                            .FirstOrDefault(a => a.Id.Equals(VraagId))
                            );
                    _analyseRepository.SaveChanges();
                    return RedirectToAction("KVraagS4Overzicht", new { AnalyseId });
                }
                if (VraagNr == 5)
                {
                    analyse.Kosten
                        .Kvragen5
                        .Remove(analyse
                            .Kosten
                            .Kvragen5
                            .FirstOrDefault(a => a.Id.Equals(VraagId))
                            );
                    _analyseRepository.SaveChanges();
                    return RedirectToAction("KVraagS5Overzicht", new { AnalyseId });
                }
                if (VraagNr == 6)
                {
                    analyse.Kosten
                        .Kvragen6
                        .Remove(analyse
                            .Kosten
                            .Kvragen6
                            .FirstOrDefault(a => a.Id.Equals(VraagId))
                            );
                    _analyseRepository.SaveChanges();
                    return RedirectToAction("KVraagS6Overzicht", new { AnalyseId });
                }
                if (VraagNr == 7)
                {
                    analyse.Kosten
                        .Kvragen7
                        .Remove(analyse
                            .Kosten
                            .Kvragen7
                            .FirstOrDefault(a => a.Id.Equals(VraagId))
                            );
                    _analyseRepository.SaveChanges();
                    return RedirectToAction("KVraagS7Overzicht", new { AnalyseId });
                }
            }
            catch
            {
                TempData["error"] = $"Sorry, something went wrong.";
            }
            return NotFound();
        }
    }
}
