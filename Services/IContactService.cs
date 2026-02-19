using ContactManagement.Api.Core.Dtos;
using ContactManagement.Api.Core.Entities;

namespace ContactManagement.Api.Services;

public interface IContactService
{
    Task<List<ContactDto>> GetAllAsync();
    Task<ContactDto> GetByIdAsync(int id);
    Task<ContactDto> CreateAsync(ContactDto contact);
    Task<ContactDto> UpdateAsync(int id, ContactDto contact);
    Task<bool> DeleteAsync(int id);
}
