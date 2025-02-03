using PetProject.Core.Entities;

namespace PetProject.Core.DomainServices;

public interface IEventService
{
    void CreateEvent(Events events);
}