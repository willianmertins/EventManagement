namespace EventManagement.Application.DTOs
{
    public record CreateEventRequest(string Title, string Description, DateTime EventDate);
    public record EventResponse(Guid Id, string Title, string Description, DateTime EventDate, Guid OrganizerId);
}
