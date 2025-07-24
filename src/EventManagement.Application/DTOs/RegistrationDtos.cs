namespace EventManagement.Application.DTOs
{
    public record RegisterToEventRequest(Guid EventId);
    public record RegistrationResponse(Guid RegistrationId, Guid EventId, Guid UserId, DateTime RegisteredAt);
}
