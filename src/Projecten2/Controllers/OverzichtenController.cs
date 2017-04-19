using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projecten2.Models.Domain;
using Projecten2.Models.Domain.KostenVragen;
using Projecten2.Models.ViewModels.KostenViewModels;

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
        [HttpPost]
        public IActionResult KVraagS1Overzicht()
        {
            return View();
        }
    }
}
