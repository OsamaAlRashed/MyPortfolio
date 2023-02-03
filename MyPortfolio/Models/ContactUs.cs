using MyPortfolio.Models.Base;

namespace MyPortfolio.Models
{
    public class ContactUs : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
