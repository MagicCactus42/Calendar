namespace PetProject.Core.ValueObjects;

public sealed record From
{
    public DateTimeOffset Value { get; }

    public From(DateTimeOffset value)
    {
        Value = value;
    }
}