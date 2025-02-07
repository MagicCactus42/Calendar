using PetProject.Core.Exceptions;
using PetProject.Core.ValueObjects;

namespace PetProject.Application.Exceptions;

public sealed class UserNotFoundException : CustomException
{
    public UserNotFoundException(UserId userId) : base($"User with UserId: {userId} was not found.}}")
    {
    }
}