using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Dtos
{
    public class ContactDto
    {
        public Guid Id { get; set; }

        [Required( ErrorMessage = "Please, enter your name.")]
        public string Name { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter your message.")]
        public string Message { get; set; }
    }
}
