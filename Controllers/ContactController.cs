using ContactManagement.Api.Context;
using ContactManagement.Api.Core.Dtos;
using ContactManagement.Api.Core.Entities;
using ContactManagement.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    public readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _contactService.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(ContactDto contactDto)
    {
        var created = await _contactService.CreateAsync(contactDto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var contact = await _contactService.GetByIdAsync(id);

        if (contact == null)
        {
            return NotFound();
        }

        return Ok(contact);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ContactDto contactDto)
    {
        var updated = await _contactService.UpdateAsync(id, contactDto);

        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {

        bool deleted = await _contactService.DeleteAsync(id);

        if (!deleted)
            return NotFound(); // 404 se não existia

        return NoContent(); // 204 se deletou
    }


}
