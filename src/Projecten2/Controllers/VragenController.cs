using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projecten2.Models.Domain;
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

        public IActionResult KVraagS1()
        {
            return View();
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
    }
}
