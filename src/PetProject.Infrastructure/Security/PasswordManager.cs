using Microsoft.AspNetCore.Identity;
using PetProject.Application.Security;
using PetProject.Core.Entities;

namespace PetProject.Infrastructure.Security;

internal sealed class PasswordManager : IPasswordManager
{
    private readonly IPasswordHasher<User> _passwordHasher;

    public PasswordManager(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }
    public string Secure(string password) 
        => _passwordHasher.HashPassword(default, password);

    public bool Validate(string password, string securedPassword)
        => _passwordHasher.VerifyHashedPassword(default, securedPassword, password) is PasswordVerificationResult.Success;
}