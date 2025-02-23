using Calendar.Application.Abstractions;

namespace Calendar.Application.Commands;

public record RemoveEvent(Guid EventId) : ICommand;