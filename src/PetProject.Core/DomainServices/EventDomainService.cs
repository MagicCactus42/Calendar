using PetProject.Core.Abstractions;
using PetProject.Core.Entities;
using PetProject.Core.Exceptions;
using PetProject.Core.Policies;
using PetProject.Core.ValueObjects;

namespace PetProject.Core.DomainServices;

internal sealed class EventDomainService : IEventDomainService
{
    private readonly IEnumerable<IEventPolicy> _eventPolicy;
    private readonly IClock _clock;

    public EventDomainService(IEnumerable<IEventPolicy> eventPolicy, IClock clock)
    {
        _eventPolicy = eventPolicy;
        _clock = clock;
    }

    public void CreateEventService(Events events, Role role, IEnumerable<Events> eventsEnumerable)
    {
        var scheduledEvents = new ScheduledEvent(events.EventId, events.EventName, events.EventDescription, events.From,
            events.To, true, events.OwnerId, events.CanOverlap);

        var policy = _eventPolicy.SingleOrDefault(x => x.CanBeApplied(role));

        if (policy is null)
            throw new NoEventPolicyFoundException(role);

        if (policy.CanAddEvent(eventsEnumerable, events.OwnerId) is false)
            throw new CannotAddEventException();
        
        events.AddEvent(scheduledEvents, new Date(_clock.Current()));
    }
}