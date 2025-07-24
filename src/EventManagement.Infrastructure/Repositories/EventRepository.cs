using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces;
using EventManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Infrastructure.Repositories
{
    public class EventRepository(AppDbContext context) : IEventRepository
    {
        private readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task AddAsync(Event ev)
        {
            await _context.Events.AddAsync(ev);
            await _context.SaveChangesAsync();
        }

        async Task<Event?> IEventRepository.GetByIdAsync(Guid id) => await _context.Events.FindAsync(id);

        public async Task<IEnumerable<Event>> GetEventsByOrganizerAsync(Guid organizerId)
        {
            return await _context.Events
                .Where(e => e.OrganizerId == organizerId)
                .ToListAsync();
        }
    }
}
