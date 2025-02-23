namespace Calendar.Core.Abstractions;

public interface IClock
{
    DateTimeOffset Current();
}