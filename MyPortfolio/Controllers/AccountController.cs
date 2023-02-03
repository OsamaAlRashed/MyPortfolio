using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Dtos;
using MyPortfolio.Services.IdentityService;

namespace MyPortfolio.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityRepo repo;

        public AccountController(IIdentityRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto, string returnUrl)
        {
            var result = await repo.Login(dto.UserName, dto.Password);
            if (result == null)
                return Unauthorized();

            return Redirect(returnUrl ?? "/");
        }
    }
}
