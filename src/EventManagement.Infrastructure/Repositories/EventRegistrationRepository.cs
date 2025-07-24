using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces;
using EventManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Infrastructure.Repositories
{
    public class EventRegistrationRepository(AppDbContext context) : IEventRegistrationRepository
    {
        private readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<EventRegistration>> GetRegistrationsByUserAsync(Guid userId)
        {
            return await _context.Registrations
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task RegisterAsync(EventRegistration registration)
        {
            await _context.Registrations.AddAsync(registration);
            await _context.SaveChangesAsync();
        }
    }
}
