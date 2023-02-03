using MyPortfolio.Dtos;

namespace MyPortfolio.Services.ProjectService
{
    public interface IProjectRepo
    {
        Task<Guid?> Add(ProjectDto dto);
        Task<bool> Update(ProjectDto dto);
        Task<bool> Delete(Guid id);
        Task<ProjectDto?> GetById(Guid id);
        Task<List<ProjectDto>> GetAll();
    }
}
