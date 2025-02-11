using PetProject.Core.Exceptions;

namespace PetProject.Application.Exceptions;

public class UsernameAlreadyInUseException : CustomException
{
    public UsernameAlreadyInUseException(string username) : base($"{username} is already in use.")
    {
    }
}