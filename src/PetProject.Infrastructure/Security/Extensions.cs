using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Application.Security;
using PetProject.Core.Entities;

namespace PetProject.Infrastructure.Security;

internal static class Extensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddSingleton<IPasswordManager, PasswordManager>();
        
        return services;
    }
}