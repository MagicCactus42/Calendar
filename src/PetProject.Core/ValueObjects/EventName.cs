using PetProject.Core.Exceptions;

namespace PetProject.Core.ValueObjects;

public sealed record EventName
{
    public string Value { get; }

    public EventName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidEventNameException();
        
        Value = value;
    }
    
    public static implicit operator string(EventName eventName) => eventName.Value;
    public static implicit operator EventName(string eventName) => new(eventName);
    public override string ToString() => Value;
}