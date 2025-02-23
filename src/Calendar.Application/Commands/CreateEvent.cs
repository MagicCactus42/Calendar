using Calendar.Application.Abstractions;

namespace Calendar.Application.Commands;

public record CreateEvent(string EventName, string EventDescription, DateTimeOffset From, DateTimeOffset To, Guid OwnerId, bool CanOverlap) : ICommand;