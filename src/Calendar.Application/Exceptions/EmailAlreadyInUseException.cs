using Calendar.Core.Exceptions;

namespace Calendar.Application.Exceptions;

public sealed class EmailAlreadyInUseException : CustomException
{
    public EmailAlreadyInUseException(string email) : base($"{email} is already in use.")
    {
    }
}