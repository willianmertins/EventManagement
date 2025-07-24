using EventManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Event>().HasKey(e => e.Id);
            builder.Entity<EventRegistration>().HasKey(r => r.Id);
        }
    }
}
