namespace EventManagement.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime EventDate { get; private set; }
        public Guid OrganizerId { get; private set; }

        private Event(Guid id, string title, string description, DateTime eventDate, Guid organizerId)
        {
            Id = id;
            Title = title;
            Description = description;
            EventDate = eventDate;
            OrganizerId = organizerId;
        }

        private Event() { }

        public static Event Create(string title, string description, DateTime eventDate, Guid organizerId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.", nameof(title));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty.", nameof(description));

            if (eventDate < DateTime.UtcNow)
                throw new ArgumentException("Event date must be in the future.", nameof(eventDate));

            return new Event(Guid.NewGuid(), title, description, eventDate, organizerId);
        }
    }
}
