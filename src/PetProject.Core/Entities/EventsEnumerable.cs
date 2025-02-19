using PetProject.Core.Exceptions;
using PetProject.Core.ValueObjects;

namespace PetProject.Core.Entities;

public class EventsEnumerable
{
    private readonly HashSet<Events> _events = new();

    public IEnumerable<Events> Events => _events;
    
    public void AddEvent(Events events, Date now)
    {
        if (events.To.Value < events.From.Value || events.To.Value < now.Value)
            throw new InvalidEventTimeInterval();

        if (!events.CanOverlap && _events.Any(x =>
                x.From.Value < events.To.Value && x.To.Value > events.From.Value))
            throw new EventTimeIntervalOverlapException();
        
        _events.Add(events);
    }

    public void RemoveEvent(EventId eventId)
        => _events.RemoveWhere(x => x.EventId == eventId);

    public void RemoveEvents(IEnumerable<Events> scheduledEvents)
        => _events.RemoveWhere(x => scheduledEvents.Any(r => r.EventId == x.EventId));
}