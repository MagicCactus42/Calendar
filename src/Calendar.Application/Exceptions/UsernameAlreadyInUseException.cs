using Calendar.Core.Exceptions;

namespace Calendar.Application.Exceptions;

public sealed class UsernameAlreadyInUseException : CustomException
{
    public UsernameAlreadyInUseException(string username) : base($"{username} is already in use.")
    {
    }
}