using PetProject.Application.Abstractions;

namespace PetProject.Application.Commands;

public record RemoveEvent(Guid UserId, Guid EventId) : ICommand;