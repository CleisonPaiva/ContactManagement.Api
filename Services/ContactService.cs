using ContactManagement.Api.Context;
using ContactManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Api.Services;

public class ContactService : IContactService
{
    private readonly ContactContext _context;

    public ContactService(ContactContext context)
    {
        _context = context;
    }

    public async Task<List<Contact>> GetAllAsync()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task<Contact> CreateAsync(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact?> GetByIdAsync(int id)
    {
        return await _context.Contacts.FindAsync(id);
    }

    public async Task<Contact> UpdateAsync(int id, Contact contact)
    {
        var contactDb = await _context.Contacts.FindAsync(id);

        if (contactDb == null)
            return null;

        contactDb.FirstName = contact.FirstName;
        contactDb.LastName = contact.LastName;
        contactDb.Email = contact.Email;
        contactDb.PhoneNumber = contact.PhoneNumber;
        contactDb.IsActive = contact.IsActive;
        contactDb.CreatedAt = contact.CreatedAt;
        contactDb.UpdatedAt = DateTime.UtcNow;

        _context.Contacts.Update(contactDb);
        await _context.SaveChangesAsync();

        return contactDb;
    }
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
