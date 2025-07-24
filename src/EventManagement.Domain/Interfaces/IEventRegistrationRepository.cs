using EventManagement.Domain.Entities;

namespace EventManagement.Domain.Interfaces
{
    public interface IEventRegistrationRepository
    {
        Task RegisterAsync(EventRegistration registration);
        Task<IEnumerable<EventRegistration>> GetRegistrationsByUserAsync(Guid userId);  
    }
}
