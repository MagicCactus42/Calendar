namespace Calendar.Core.ValueObjects;

public sealed record To
{
    public DateTimeOffset Value { get; }

    public To(DateTimeOffset value)
    {
        Value = value;
    }
    
    public static implicit operator DateTimeOffset(To to) => to.Value;
    public static implicit operator To(DateTimeOffset value) => new(value);
}