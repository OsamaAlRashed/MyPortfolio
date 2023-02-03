using Microsoft.EntityFrameworkCore;
using MyPortfolio.Dtos;
using MyPortfolio.Helpers;
using MyPortfolio.Models;
using System.IO;

namespace MyPortfolio.Services.ProjectService
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProjectRepo(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<Guid?> Add(ProjectDto dto)
        {
            try
            {
                var path = "";
                if (dto.ImageFile != null)
                {
                    path = await dto.ImageFile.TryUploadImageAsync("projects", webHostEnvironment.WebRootPath);
                }

                var model = new Project
                {
                    Description = dto.Description,
                    ImagePath = path,
                    Link = dto.Link,
                    Title = dto.Title,
                };

                context.Projects.Add(model);
                await context.SaveChangesAsync();

                return model.Id;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var project = await context.Projects
                    .Where(x => x.Id == id).SingleOrDefaultAsync();

                if(project != null)
                {
                    context.Projects.Remove(project);
                    await context.SaveChangesAsync();

                    return true;
                }
            }
            catch 
            {
            }

            return false;
        }

        public async Task<List<ProjectDto>> GetAll()
        {
            try
            {
                var projects = await context.Projects
                .Select(x => new ProjectDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    ImagePath = x.ImagePath,
                    Link = x.Link,
                    Title = x.Title
                }).ToListAsync();

                return projects;
            }
            catch
            {
                return new List<ProjectDto>();
            }
        }

        public async Task<ProjectDto?> GetById(Guid id)
        {
            try
            {
                var project = await context.Projects
                    .Where(x => x.Id == id)
                    .Select(x => new ProjectDto
                    {
                        Id = x.Id,
                        Description = x.Description,
                        ImagePath = x.ImagePath,
                        Link = x.Link,
                        Title = x.Title
                    }).SingleOrDefaultAsync();

                return project;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Update(ProjectDto dto)
        {
            try
            {
                var project = await context.Projects
                    .Where(x => x.Id == dto.Id).SingleOrDefaultAsync();

                if(project == null)
                    return false;

                if (dto.ImageFile != null)
                {
                    project.ImagePath = await dto.ImageFile.TryUploadImageAsync("projects", webHostEnvironment.WebRootPath);
                }

                project.Title = dto.Title;
                project.Description = dto.Description;
                project.Link = dto.Link;

                await context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
