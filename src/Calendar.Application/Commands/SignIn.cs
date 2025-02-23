using Abstractions_ICommand = Calendar.Application.Abstractions.ICommand;

namespace Calendar.Application.Commands;

public record SignIn(string Email, string Password) : Abstractions_ICommand;