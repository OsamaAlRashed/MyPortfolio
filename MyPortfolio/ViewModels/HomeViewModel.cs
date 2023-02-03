using MyPortfolio.Dtos;

namespace MyPortfolio.ViewModels
{
    public class HomeViewModel
    {
        public OwnerDto Owner { get; set; }
        public List<ProjectDto> Projects { get; set; }
    }
}
