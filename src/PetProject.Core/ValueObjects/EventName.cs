using PetProject.Core.Exceptions;

namespace PetProject.Core.ValueObjects;

public sealed record EventName
{
    private string Name { get; }

    public EventName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidEventNameException();
        
        Name = name;
    }
    
    public static implicit operator string(EventName eventName) => eventName.Name;
    public static implicit operator EventName(string eventName) => new(eventName);
    public override string ToString() => Name;
}