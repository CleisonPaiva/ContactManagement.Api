using ContactManagement.Api.Core.Dtos;
using ContactManagement.Api.Core.Dtos.Pagination;
using ContactManagement.Api.Core.Entities;

namespace ContactManagement.Api.Services;

public interface IContactService
{
    Task<PagedResponseDto<ContactDto>> GetAllAsync(PagedRequestDto requestDto);
    Task<ContactDto> GetByIdAsync(int id);
    Task<ContactDto> CreateAsync(ContactDto contact);
    Task<ContactDto> UpdateAsync(int id, ContactDto contact);
    Task<bool> DeleteAsync(int id);
}
