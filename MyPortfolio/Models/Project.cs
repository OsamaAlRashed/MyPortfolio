using MyPortfolio.Models.Base;

namespace MyPortfolio.Models
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string ImagePath { get; set; }

        public string Tags { get; set; }
    }
}
