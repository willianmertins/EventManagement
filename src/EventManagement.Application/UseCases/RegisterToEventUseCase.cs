using EventManagement.Application.DTOs;
using EventManagement.Domain.Entities;
using EventManagement.Domain.Interfaces;
using System.Security.Claims;

namespace EventManagement.Application.UseCases;

public class RegisterToEventUseCase(IEventRegistrationRepository registrationRepository)
{
    private readonly IEventRegistrationRepository _registrationRepository = registrationRepository;

    public async Task<RegistrationResponse> ExecuteAsync(RegisterToEventRequest request, ClaimsPrincipal user)
    {
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
            throw new UnauthorizedAccessException("Usuário não autenticado corretamente.");

        var registration = EventRegistration.Register(request.EventId, userId);

        await _registrationRepository.RegisterAsync(registration);

        return new RegistrationResponse(
            registration.Id,
            registration.EventId,
            registration.UserId,
            registration.RegisteredAt);
    }
}