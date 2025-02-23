using Calendar.Core.Entities;
using Calendar.Core.ValueObjects;

namespace Calendar.Core.Policies;

internal sealed class OwnerEventPolicy : IEventPolicy
{
    public bool CanBeApplied(Role role)
        => role == "owner";

    public bool CanAddEvent(IEnumerable<Events> events, UserId userId)
        => true;
}