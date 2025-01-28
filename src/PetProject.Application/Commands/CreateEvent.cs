namespace PetProject.Application.Commands;

public record CreateEvent(string EventName, string EventDescription, DateTimeOffset From, DateTimeOffset To, Guid OwnerId);