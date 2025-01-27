namespace PetProject.Core.ValueObjects;

public sealed record EventDescription
{
    public string Value { get; }

    public EventDescription(string value)
    {
        Value = value;
    }
    
    public static implicit operator string(EventDescription eventDescription) => eventDescription.Value;
    public static implicit operator EventDescription(string value) => new(value);
    public override string ToString() => Value;
}