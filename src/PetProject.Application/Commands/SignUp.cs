using ICommand = PetProject.Application.Abstractions.ICommand;

namespace PetProject.Application.Commands;

public record SignUp(Guid UserId, string Email, string Password, string Username, string Role) : ICommand;