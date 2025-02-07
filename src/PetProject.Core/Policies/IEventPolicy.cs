using PetProject.Core.Entities;
using PetProject.Core.ValueObjects;

namespace PetProject.Core.Policies;

public interface IEventPolicy
{
    bool CanBeApplied(Role role);
    bool CanAddEvent(IEnumerable<Events> events, UserId userId);
}