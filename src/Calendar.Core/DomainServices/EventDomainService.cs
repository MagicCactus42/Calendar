using Calendar.Core.Abstractions;
using Calendar.Core.Entities;
using Calendar.Core.Exceptions;
using Calendar.Core.Policies;
using Calendar.Core.ValueObjects;

namespace Calendar.Core.DomainServices;

internal sealed class EventDomainService : IEventDomainService
{
    private readonly IEnumerable<IEventPolicy> _eventPolicy;
    private readonly IClock _clock;

    public EventDomainService(IEnumerable<IEventPolicy> eventPolicy, IClock clock)
    {
        _eventPolicy = eventPolicy;
        _clock = clock;
    }

    public void CreateEventService(Events events, Role role, EventsEnumerable eventsEnumerable)
    {
        var eventsList = eventsEnumerable.Events.ToList();
        var policy = _eventPolicy.SingleOrDefault(x => x.CanBeApplied(role));
        if (policy is null)
            throw new NoEventPolicyFoundException(role);

        if (policy.CanAddEvent(eventsList, events.OwnerId) is false)
            throw new CannotAddEventException();
        
        eventsEnumerable.AddEvent(events, new Date(_clock.Current()));
    }
}