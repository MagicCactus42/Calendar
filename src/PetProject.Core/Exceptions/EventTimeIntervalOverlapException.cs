namespace PetProject.Core.Exceptions;

public class EventTimeIntervalOverlapException : CustomException
{
    public EventTimeIntervalOverlapException() : base("Event time interval overlap another event that cannot be overlapped")
    {
    }
}