namespace PetProject.Core.Exceptions;

public class InvalidPasswordException : CustomException
{
    public InvalidPasswordException() : base("Password is invalid.")
    {
    }
}