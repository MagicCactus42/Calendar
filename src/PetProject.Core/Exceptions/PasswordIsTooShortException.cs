namespace PetProject.Core.Exceptions;

public class PasswordIsTooShortException : CustomException
{
    public PasswordIsTooShortException() : base("Password is too short")
    {
    }
}