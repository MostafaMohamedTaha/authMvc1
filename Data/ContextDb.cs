// Ignore Spelling: authentication

using authentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace authentication.Data
{
    public class ContextDb : IdentityDbContext
    {
        public ContextDb(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SalesLead> SalesLeads { get; set; }
    }
}
