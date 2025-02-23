namespace Calendar.Core.Exceptions;

public class InvalidEventNameException : CustomException
{
    public InvalidEventNameException() : base("Invalid Event Name")
    {
    }
}