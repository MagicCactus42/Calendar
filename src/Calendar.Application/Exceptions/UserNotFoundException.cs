using Calendar.Core.Exceptions;
using Calendar.Core.ValueObjects;

namespace Calendar.Application.Exceptions;

public sealed class UserNotFoundException : CustomException
{
    public UserNotFoundException(UserId userId) : base($"User with UserId: {userId} was not found.}}")
    {
    }
}