using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Dtos;
using MyPortfolio.Services.ContactService;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepo repo;

        public ContactController(IContactRepo repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await repo.GetAll());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var portfolioItem = await repo.GetById(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            var dto = new ContactDto()
            {
                Message = collection["message"],
                Name = collection["name"],
                Phone = collection["phone"],
                Email = collection["email"]
            };

            await repo.Add(dto);
            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var dto = await repo.GetById(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await repo.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
