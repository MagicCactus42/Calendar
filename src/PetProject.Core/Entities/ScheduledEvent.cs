using PetProject.Core.ValueObjects;

namespace PetProject.Core.Entities;

public class ScheduledEvent
{

    public EventId EventId { get; private set; }
    public EventName EventName { get; private set; }
    public EventDescription EventDescription { get; private set; }
    public From From { get; private set; }
    public To To { get; private set; }
    public bool IsActive { get; private set; }
    public UserId OwnerId { get; private set; }
    public bool CanOverlap { get; private set; }
    
    public ScheduledEvent(EventId eventId, EventName eventName, EventDescription eventDescription, From from, To to, bool isActive, UserId ownerId, bool canOverlap)
    {
        EventId = eventId;
        EventName = eventName;
        EventDescription = eventDescription;
        From = from;
        To = to;
        IsActive = isActive;
        OwnerId = ownerId;
        CanOverlap = canOverlap;
    }
}