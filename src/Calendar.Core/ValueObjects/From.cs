namespace Calendar.Core.ValueObjects;

public sealed record From
{
    public DateTimeOffset Value { get; }

    public From(DateTimeOffset value)
    {
        Value = value;
    }
    
    public static implicit operator DateTimeOffset(From from) => from.Value;
    public static implicit operator From(DateTimeOffset value) => new(value);
}