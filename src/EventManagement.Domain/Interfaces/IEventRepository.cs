using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task AddAsync(Event ev);
        Task<Event?> GetByIdAsync(Guid id);
        Task<IEnumerable<Event>> GetEventsByOrganizerAsync(Guid organizerId);
    }
}
