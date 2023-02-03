using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Dtos;
using MyPortfolio.Models;
using MyPortfolio.Services.IdentityService;
using MyPortfolio.Services.ProjectService;
using MyPortfolio.ViewModels;
using System.Diagnostics;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectRepo repo;

        public HomeController(ILogger<HomeController> logger, IProjectRepo repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new HomeViewModel()
            {
                Owner = new OwnerDto
                {
                    Avatar = "osama.jpg",
                    FullName = "Osama Al-Rashed",
                    Profile = "Software Engineer   .Net Back End Developer",
                    CvLink = "https://docs.google.com/document/d/1tEQWbL_vU41z3JFiGyCzbrAxGgjBxcWDAko1vsGsiJs",
                    Address = new AddressDto
                    {
                        City = "Dubai",
                        Number = 1,
                        Street = "AlBarsha"
                    }
                },
                Projects = await repo.GetAll()
            };

            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}