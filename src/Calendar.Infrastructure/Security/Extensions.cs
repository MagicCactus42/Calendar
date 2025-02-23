using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Calendar.Application.Security;
using Calendar.Core.Entities;

namespace Calendar.Infrastructure.Security;

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