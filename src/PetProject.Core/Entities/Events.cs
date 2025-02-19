using PetProject.Core.Exceptions;
using PetProject.Core.ValueObjects;

namespace PetProject.Core.Entities;

public class Events
{
    public EventId EventId { get; }
    public EventName EventName { get; private set; }
    public EventDescription EventDescription { get; private set; }
    public From From { get; private set; }
    public To To { get; private set; }
    public bool IsActive { get; private set; }
    public UserId OwnerId { get; private set; }
    public bool CanOverlap { get; private set; }

    public Events(EventId eventId, EventName eventName, EventDescription eventDescription, bool isActive, From from, To to, UserId ownerId, bool canOverlap)
    {
        EventId = eventId;
        EventName = eventName;
        EventDescription = eventDescription;
        IsActive = isActive;
        From = from;
        To = to;
        OwnerId = ownerId;
        CanOverlap = canOverlap;
    }

    public static Events Create(EventName eventName, EventDescription eventDescription, From from, To to) => new(Guid.NewGuid(), eventName, eventDescription, true, from, to, Guid.NewGuid(), true );
}