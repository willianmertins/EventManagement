namespace EventManagement.Domain.Entities
{
    public class EventRegistration
    {
        public Guid Id { get; private set; }
        public Guid EventId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime RegisteredAt { get; private set; }

        private EventRegistration(Guid id, Guid eventId, Guid userId)
        {
            Id = id;
            EventId = eventId;
            UserId = userId;
            RegisteredAt = DateTime.UtcNow;
        }

        public static EventRegistration Register(Guid eventId, Guid userId)
        {
            if (eventId == Guid.Empty)
                throw new ArgumentException("Event ID cannot be empty.", nameof(eventId));
            
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty.", nameof(userId));

            return new EventRegistration(Guid.NewGuid(), eventId, userId);
        }
    }
}
