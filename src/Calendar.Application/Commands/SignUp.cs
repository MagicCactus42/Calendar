using Abstractions_ICommand = Calendar.Application.Abstractions.ICommand;

namespace Calendar.Application.Commands;

public record SignUp(Guid UserId, string Email, string Password, string Username, string Role) : Abstractions_ICommand;