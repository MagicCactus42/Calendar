using System.Security.Authentication;
using Calendar.Application.Abstractions;
using Calendar.Application.Security;
using Calendar.Core.Repositories;

namespace Calendar.Application.Commands.Handlers;

internal sealed class SignInHandler : ICommandHandler<SignIn>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticator _authenticator;
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenStorage _tokenStorage;

    public SignInHandler(IUserRepository userRepository, IAuthenticator authenticator, IPasswordManager passwordManager, ITokenStorage tokenStorage)
    {
        _userRepository = userRepository;
        _authenticator = authenticator;
        _passwordManager = passwordManager;
        _tokenStorage = tokenStorage;
    }
    public async Task HandleAsync(SignIn command)
    {
        var user = await _userRepository.GetByEmailAsync(command.Email);
        if (user is null)
            throw new InvalidCredentialException();
        
        if (!_passwordManager.Validate(command.Password, user.Password))
            throw new InvalidCredentialException();

        var jwt = _authenticator.CreateToken(user.UserId, user.Role);
        _tokenStorage.Set(jwt);
    }
}