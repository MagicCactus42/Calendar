using Calendar.Core.Entities;
using Calendar.Core.ValueObjects;

namespace Calendar.Core.Policies;

public interface IEventPolicy
{
    bool CanBeApplied(Role role);
    bool CanAddEvent(IEnumerable<Events> events, UserId userId);
}