using PetProject.Core.Exceptions;

namespace PetProject.Core.ValueObjects;

public sealed record EventId
{
    private Guid Value { get; }

    public EventId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEventIdException();
        
        Value = value;
    }
    
    public static implicit operator Guid(EventId eventId) => eventId.Value;
    public static implicit operator EventId(Guid eventId) => new(eventId);
}