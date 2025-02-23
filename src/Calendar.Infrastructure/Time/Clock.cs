using Calendar.Core.Abstractions;

namespace Calendar.Infrastructure.Time;

public class Clock : IClock
{
    public DateTimeOffset Current() => DateTimeOffset.UtcNow;
}