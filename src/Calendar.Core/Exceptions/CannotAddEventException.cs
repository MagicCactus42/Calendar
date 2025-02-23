namespace Calendar.Core.Exceptions;

public sealed class CannotAddEventException : CustomException
{
    public CannotAddEventException() : base("Can not add event")
    {
    }
}