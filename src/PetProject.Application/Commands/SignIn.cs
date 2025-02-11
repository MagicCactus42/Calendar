using ICommand = PetProject.Application.Abstractions.ICommand;

namespace PetProject.Application.Commands;

public record SignIn(string Email, string Password) : ICommand;