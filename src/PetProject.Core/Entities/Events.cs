using PetProject.Core.Exceptions;
using PetProject.Core.ValueObjects;

namespace PetProject.Core.Entities;

public class Events
{
    private readonly HashSet<ScheduledEvent> _scheduledEvents = new();
    public EventId EventId { get; }
    public EventName EventName { get; private set; }
    public EventDescription EventDescription { get; private set; }
    public From From { get; private set; }
    public To To { get; private set; }
    public bool IsActive { get; private set; }
    public UserId OwnerId { get; private set; }
    public bool CanOverlap { get; private set; }
    public IEnumerable<ScheduledEvent> ScheduledEvents => _scheduledEvents;

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

    internal void AddEvent(ScheduledEvent scheduledEvent, Date now)
    {
        if (scheduledEvent.To.Value < scheduledEvent.From.Value || scheduledEvent.To.Value < now.Value)
            throw new InvalidEventTimeInterval();

        if (!scheduledEvent.CanOverlap && _scheduledEvents.Any(x =>
                x.From.Value < scheduledEvent.From.Value && x.To.Value > scheduledEvent.From.Value))
            throw new EventTimeIntervalOverlapException();
        
        _scheduledEvents.Add(scheduledEvent);
    }
    
    internal void RemoveEvent(EventId eventId)
        => _scheduledEvents.RemoveWhere(x => x.EventId == eventId);

    internal void RemoveEvents(IEnumerable<ScheduledEvent> scheduledEvents)
        => _scheduledEvents.RemoveWhere(x => scheduledEvents.Any(r => r.EventId == x.EventId));
}