using Calendar.Core.Exceptions;

namespace Calendar.Application.Exceptions;

public sealed class EventNotFoundException : CustomException
{
    public EventNotFoundException(Guid id) : base($"Event with id: {id} was not found")
    {
    }
}