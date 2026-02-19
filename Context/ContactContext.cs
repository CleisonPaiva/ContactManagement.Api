

using ContactManagement.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Api.Context;


public class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {
    }
    public DbSet<Contact> Contacts { get; set; }
}
