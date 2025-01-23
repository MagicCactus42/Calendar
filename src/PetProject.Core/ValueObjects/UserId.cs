using PetProject.Core.Exceptions;

namespace PetProject.Core.ValueObjects;

public sealed record UserId
{
    private Guid Value { get; }

    public UserId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidUserIdException(value);
        
        Value = value;
    }

    public static implicit operator Guid(UserId userId) => userId.Value;
    public static implicit operator UserId(Guid userId) => new(userId);
}