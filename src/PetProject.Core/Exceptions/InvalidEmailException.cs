namespace PetProject.Core.Exceptions;

public class InvalidEmailException : CustomException
{
    public InvalidEmailException(string email) : base($"email {email} is invalid}}")
    {
    }
}