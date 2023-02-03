using MyPortfolio.Dtos;

namespace MyPortfolio.Services.ContactService
{
    public interface IContactRepo
    {
        Task<Guid?> Add(ContactDto dto);
        Task<bool> Delete(Guid id);
        Task<ContactDto?> GetById(Guid id);
        Task<List<ContactDto>> GetAll();
    }
}
