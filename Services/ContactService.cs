using AutoMapper;
using ContactManagement.Api.Context;
using ContactManagement.Api.Core.Dtos;
using ContactManagement.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Api.Services;

public class ContactService : IContactService
{
    private readonly ContactContext _context;
    private readonly IMapper _mapper;

    public ContactService(ContactContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ContactDto>> GetAllAsync()
    {
        var contacts = await _context.Contacts.ToListAsync();
        return _mapper.Map<List<ContactDto>>(contacts);
    }

    public async Task<ContactDto> CreateAsync(ContactDto contactDto)
    {
        // DTO → Entity para salvar no banco
        var contact = _mapper.Map<Contact>(contactDto);

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();

        // Entity → DTO para devolver
        return _mapper.Map<ContactDto>(contact);
    }

    public async Task<ContactDto?> GetByIdAsync(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        if (contact is null)
            return null;

        return _mapper.Map<ContactDto>(contact);
    }

    public async Task<ContactDto?> UpdateAsync(int id, ContactDto contactDto)
    {
        var contactDb = await _context.Contacts.FindAsync(id);

        if (contactDb is null)
            return null;

        // atualiza a entity existente com os dados do DTO
        // sem precisar campo a campo
        _mapper.Map(contactDto, contactDb);

        contactDb.UpdatedAt = DateTime.UtcNow; // sempre o horário atual

        await _context.SaveChangesAsync();

        return _mapper.Map<ContactDto>(contactDb);
    }

    //SEM USAR DTO
    /*   public async Task<ContactDto> UpdateAsync(int id, ContactDto contactDto)
       {
           var contactDb = await _context.Contacts.FindAsync(id);

           if (contactDb == null)
               return null;

           contactDb.FirstName = contactDto.FirstName;
           contactDb.LastName = contactDto.LastName;
           contactDb.Email = contactDto.Email;
           contactDb.PhoneNumber = contactDto.PhoneNumber;
           contactDb.IsActive = contactDto.IsActive;
           contactDb.CreatedAt = contactDto.CreatedAt;
           contactDb.UpdatedAt = DateTime.UtcNow;

           _context.Contacts.Update(contactDb);
           await _context.SaveChangesAsync();

           return _mapper.Map<ContactDto>(contactDb);
       }*/

    public async Task<bool> DeleteAsync(int id)
    {
        var contactDb = await _context.Contacts.FindAsync(id);

        if (contactDb == null)
        {
            return false;
        }

        _context.Contacts.Remove(contactDb);
        await _context.SaveChangesAsync();

        return true;
    }
}
