using System.Net;

namespace MyPortfolio.Dtos
{
    public class OwnerDto
    {
        public string FullName { get; set; }
        public string Profile { get; set; }
        public string Avatar { get; set; }
        public string CvLink { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        public string LeetCode { get; set; }
        public string CodeForces { get; set; }
        public AddressDto Address { get; set; }
    }

    public class AddressDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
    }
}
