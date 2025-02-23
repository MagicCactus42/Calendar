using Calendar.Core.Exceptions;

namespace Calendar.Core.ValueObjects;

public sealed record UserId
{
    public Guid Value { get; }

    public UserId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidUserIdException(value);
        
        Value = value;
    }

    public static implicit operator Guid(UserId userId) => userId.Value;
    public static implicit operator UserId(Guid userId) => new(userId);
}