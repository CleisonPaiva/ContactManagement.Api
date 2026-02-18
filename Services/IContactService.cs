using ContactManagement.Api.Entities;

namespace ContactManagement.Api.Services;

public interface IContactService
{
    Task<List<Contact>> GetAllAsync();
    Task<Contact> GetByIdAsync(int id);
    Task<Contact> CreateAsync(Contact contact);
    Task<Contact> UpdateAsync(int id, Contact contact);
    Task<bool> DeleteAsync(int id);
}
