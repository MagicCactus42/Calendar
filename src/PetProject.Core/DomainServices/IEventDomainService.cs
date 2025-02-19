using PetProject.Core.Entities;
using PetProject.Core.ValueObjects;

namespace PetProject.Core.DomainServices;

public interface IEventDomainService
{
    void CreateEventService(Events events, Role role, EventsEnumerable eventsEnumerable);
}