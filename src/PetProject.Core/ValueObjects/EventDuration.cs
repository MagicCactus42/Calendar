using PetProject.Core.Exceptions;

namespace PetProject.Core.ValueObjects;

public sealed record EventDuration
{
    private DateTime From { get; }
    private DateTime To { get; }

    public EventDuration(DateTime from, DateTime to)
    {
        if (from > to || from.Date < DateTime.UtcNow.Date)
            throw new InvalidEventDurationTimeException();
        
        From = from;
        To = to;
    }
    
    public override string ToString() => $"{From} => {To}";
}