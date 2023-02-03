using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Dtos;
using MyPortfolio.Services.ProjectService;

namespace MyPortfolio.Controllers
{

    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectRepo repo;

        public ProjectController(IProjectRepo repo)
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

        public async Task<IActionResult> Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectDto dto)
        {
            if (ModelState.IsValid)
            {
                await repo.Add(dto);
                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await repo.GetById(id);
            if (dto == null)
            {
                return NotFound();
            }

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectDto dto)
        {
            if (ModelState.IsValid)
            {
                await repo.Update(dto);
                
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
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
