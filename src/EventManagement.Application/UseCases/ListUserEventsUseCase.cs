using EventManagement.Application.DTOs;
using EventManagement.Domain.Interfaces;
using System.Security.Claims;

namespace EventManagement.Application.UseCases
{
    public class ListUserEventsUseCase(IEventRepository eventRepository, IEventRegistrationRepository registrationRepository)
    {
        private readonly IEventRepository _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        private readonly IEventRegistrationRepository _registrationRepository = registrationRepository ?? throw new ArgumentNullException(nameof(registrationRepository));

        public async Task<List<EventResponse>> ExecuteAsync(ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
            {
                throw new UnauthorizedAccessException("User não autenticado corretamente");
            }

            var registrations = await _registrationRepository.GetRegistrationsByUserAsync(userId);
            var events = new List<EventResponse>();

            foreach (var registration in registrations)
            {
                var ev = await _eventRepository.GetByIdAsync(registration.EventId);
                if (ev is not null)
                {
                    events.Add(new EventResponse(
                        ev.Id,
                        ev.Title,
                        ev.Description,
                        ev.EventDate,
                        ev.OrganizerId));
                }
            };

            return events;
        }
    }
}