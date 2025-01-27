namespace PetProject.Core.ValueObjects;

public sealed record To
{
    public DateTimeOffset Value { get; }

    public To(DateTimeOffset value)
    {
        Value = value;
    }
}