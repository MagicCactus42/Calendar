namespace PetProject.Core.Exceptions;

public class InvalidEventTimeInterval : CustomException
{
    public InvalidEventTimeInterval() : base("Invalid event time interval.")
    {
    }
}