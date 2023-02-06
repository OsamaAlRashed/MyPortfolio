using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Dtos
{
    public class ProjectDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Link { get; set; }
        
        [Display(Name = "Image")]
        public string? ImagePath { get; set; }

        [Display(Name = "Image")]
        public IFormFile? ImageFile { get; set; }
        public string Tags { get; set; }
    }
}
