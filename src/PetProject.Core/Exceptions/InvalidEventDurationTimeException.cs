namespace PetProject.Core.Exceptions;

public class InvalidEventDurationTimeException : CustomException
{
    public InvalidEventDurationTimeException() : base("Event duration time is invalid.")
    {
    }
}