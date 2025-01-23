using PetProject.Core.ValueObjects;

namespace PetProject.Core.Entities;

public class Event
{
    public EventId EventId { get; set; }
    public EventName EventName { get; set; }
    public EventDescription EventDescription { get; set; }
    public EventDuration From { get; set; }
    public EventDuration To { get; set; }
    public bool IsActive { get; set; }

    public Event(EventId eventId, EventName eventName, EventDescription eventDescription, bool isActive, EventDuration from, EventDuration to)
    {
        EventId = eventId;
        EventName = eventName;
        EventDescription = eventDescription;
        IsActive = isActive;
        From = from;
        To = to;
    }
}