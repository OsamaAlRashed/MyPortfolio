using MyPortfolio.Models.Base;

namespace MyPortfolio.Models
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
    }
}
