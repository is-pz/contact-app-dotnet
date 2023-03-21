using contact_app.Models;
using Microsoft.EntityFrameworkCore;

namespace contact_app.Data
{
    public class ContactAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public ContactAppContext(DbContextOptions<ContactAppContext> options) : base(options) 
        { 
        }

    }
}
