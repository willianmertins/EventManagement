using EventManagement.Application.DTOs;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces;
using System.Security.Claims;

namespace EventManagement.Application.UseCases
{
    public class CreateEventUseCase(IEventRepository eventRepository)
    {
        private readonly IEventRepository _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));

        public async Task<EventResponse> ExecuteAsync(CreateEventRequest request, ClaimsPrincipal user)
        {
            var organizerIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (organizerIdClaim is null || !Guid.TryParse(organizerIdClaim.Value, out var organizerId))
            {
                throw new UnauthorizedAccessException("User não autenticado corretamente");
            }

            var ev = Event.Create(
                title: request.Title,
                description: request.Description,
                eventDate: request.EventDate,
                organizerId: organizerId
            );

            await _eventRepository.AddAsync(ev);

            return new EventResponse(
                ev.Id,
                ev.Title,
                ev.Description,
                ev.EventDate,
                ev.OrganizerId);
        }
    }
}
