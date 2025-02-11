using PetProject.Application.Abstractions;
using PetProject.Application.Exceptions;
using PetProject.Application.Security;
using PetProject.Core.Abstractions;
using PetProject.Core.Entities;
using PetProject.Core.Repositories;
using PetProject.Core.ValueObjects;

namespace PetProject.Application.Commands.Handlers;

internal sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IClock _clock;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;

    public SignUpHandler(IClock clock, IUserRepository userRepository, IPasswordManager passwordManager)
    {
        _clock = clock;
        _userRepository = userRepository;
        _passwordManager = passwordManager;
    }
    public async Task HandleAsync(SignUp command)
    {
        var userId = new UserId(command.UserId);
        var email = new Email(command.Email);
        var password = new Password(command.Password);
        var username = new Username(command.Username);
        var role = string.IsNullOrWhiteSpace(command.Role) ? Role.User() : new Role(command.Role);

        if (await _userRepository.GetByEmailAsync(email) is not null)
        {
            throw new EmailAlreadyInUseException(email);
        }

        if (await _userRepository.GetByUsernameAsync(username) is not null)
        {
            throw new UsernameAlreadyInUseException(username);
        }

        var securedPassword = _passwordManager.Secure(password);
        var user = new User(userId, email, securedPassword, username, _clock.Current().UtcDateTime , role);
        await _userRepository.AddAsync(user);
    }
}