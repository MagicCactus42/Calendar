using PetProject.Core.Entities;
using PetProject.Core.ValueObjects;

namespace PetProject.Core.Policies;

internal sealed class RegularUserPolicy : IEventPolicy
{
    public bool CanBeApplied(Role role)
        => role == "user";
    
    // Policy 1 - Users can only have a maximum of 5 scheduled events
    public bool CanAddEvent(IEnumerable<Events> events, UserId userId)
    {
        var totalEvents = events.Count(x => x.OwnerId == userId);

        return totalEvents <= 5;
    }
}