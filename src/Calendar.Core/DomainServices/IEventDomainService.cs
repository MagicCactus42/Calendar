using Calendar.Core.Entities;
using Calendar.Core.ValueObjects;

namespace Calendar.Core.DomainServices;

public interface IEventDomainService
{
    void CreateEventService(Events events, Role role, EventsEnumerable eventsEnumerable);
}