using Calendar.Core.Exceptions;

namespace Calendar.Core.ValueObjects;

public sealed record EventId
{
    public Guid Value { get; }

    public EventId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEventIdException();
        
        Value = value;
    }
    
    public static implicit operator Guid(EventId eventId) => eventId.Value;
    public static implicit operator EventId(Guid eventId) => new(eventId);
}