using ContactManagement.Api.Context;
using ContactManagement.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    public readonly ContactContext _context;

    public ContactController(ContactContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contacts = await _context.Contacts.ToListAsync();
        return Ok(contacts);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Contact contact)
    {
        _context.Add(contact);
        await _context.SaveChangesAsync();

        //return Ok(contact);

        return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        if(contact == null)
        {
            return NotFound();
        }

        return Ok(contact);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id,Contact contact)
    {
        var contactDb = await _context.Contacts.FindAsync(id);

        if (contact == null)
        {
            return NotFound();
        }

        contactDb.FirstName = contact.FirstName;
        contactDb.LastName = contact.LastName;
        contactDb.Email = contact.Email;
        contactDb.PhoneNumber = contact.PhoneNumber;
        contactDb.IsActive = contact.IsActive;
        contactDb.CreatedAt = contact.CreatedAt;
        contactDb.UpdatedAt = DateTime.UtcNow;

        _context.Contacts.Update(contactDb);
        await _context.SaveChangesAsync();


        return Ok(contact);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var contactDb = await _context.Contacts.FindAsync(id);

        if (contactDb == null)
        {
            return NotFound();
        }

        _context.Contacts.Remove(contactDb);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}
