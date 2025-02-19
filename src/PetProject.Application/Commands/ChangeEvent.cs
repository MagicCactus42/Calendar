using PetProject.Application.Abstractions;

namespace PetProject.Application.Commands;

public record ChangeEvent(string EventName, string EventDescription, DateTimeOffset From, DateTimeOffset To, Guid OwnerId, Guid EventId, bool CanOverlap) : ICommand;
