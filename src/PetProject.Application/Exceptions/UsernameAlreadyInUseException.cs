using PetProject.Core.Exceptions;

namespace PetProject.Application.Exceptions;

public sealed class UsernameAlreadyInUseException : CustomException
{
    public UsernameAlreadyInUseException(string username) : base($"{username} is already in use.")
    {
    }
}