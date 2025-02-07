using PetProject.Application.Abstractions;

namespace PetProject.Application.Commands;

public record RemoveEvent(Guid EventId) : ICommand;