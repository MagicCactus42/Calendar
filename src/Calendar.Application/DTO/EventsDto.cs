namespace Calendar.Application.DTO;

public class EventsDto
{
    public Guid EventId { get; set; }
    public string EventName { get; set; }
    public string EventDescription { get; set; }
    public DateTimeOffset From { get; set; }
    public DateTimeOffset To { get; set; }
    public Guid OwnerId { get; set; }
    
}