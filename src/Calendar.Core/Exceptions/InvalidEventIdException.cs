namespace Calendar.Core.Exceptions;

public class InvalidEventIdException : CustomException
{
    public InvalidEventIdException() : base("Event Id is invalid.")
    {
    }
}