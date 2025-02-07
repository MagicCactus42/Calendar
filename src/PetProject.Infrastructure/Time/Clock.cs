using PetProject.Core.Abstractions;

namespace PetProject.Infrastructure.Time;

public class Clock : IClock
{
    public DateTimeOffset Current() => DateTimeOffset.UtcNow;
}