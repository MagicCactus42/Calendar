using PetProject.Core.Entities;
using PetProject.Core.ValueObjects;

namespace PetProject.Core.Policies;

internal sealed class OwnerEventPolicy : IEventPolicy
{
    public bool CanBeApplied(Role role)
        => role == Role.Owner();

    public bool CanAddEvent(IEnumerable<Events> events, UserId userId)
        => true;
}