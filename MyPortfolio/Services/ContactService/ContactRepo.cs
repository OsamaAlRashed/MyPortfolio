using Microsoft.EntityFrameworkCore;
using MyPortfolio.Dtos;
using MyPortfolio.Models;

namespace MyPortfolio.Services.ContactService
{
    public class ContactRepo : IContactRepo
    {

        private readonly AppDbContext context;

        public ContactRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid?> Add(ContactDto dto)
        {
            try
            {
                var model = new ContactUs
                {
                    Email= dto.Email,
                    Phone= dto.Phone,
                    Message = dto.Message,
                    Name = dto.Name,
                };

                context.ContactUs.Add(model);
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
                var contact = await context.ContactUs
                    .Where(x => x.Id == id).SingleOrDefaultAsync();

                if (contact != null)
                {
                    context.ContactUs.Remove(contact);
                    await context.SaveChangesAsync();

                    return true;
                }
            }
            catch
            {
            }

            return false;
        }

        public async Task<List<ContactDto>> GetAll()
        {
            try
            {
                var contacts = await context.ContactUs
                .Select(x => new ContactDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    Phone = x.Phone,
                    Message = x.Message,
                    Name = x.Name,
                }).ToListAsync();

                return contacts;
            }
            catch
            {
                return new List<ContactDto>();
            }
        }

        public async Task<ContactDto?> GetById(Guid id)
        {
            try
            {
                var contact = await context.ContactUs
                    .Where(x => x.Id == id)
                    .Select(x => new ContactDto
                    {
                        Id = x.Id,
                        Email = x.Email,
                        Phone = x.Phone,
                        Message = x.Message,
                        Name = x.Name,
                    }).SingleOrDefaultAsync();

                return contact;
            }
            catch
            {
                return null;
            }
        }
    }
}
