using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Infrastructure.DAL;
using PetProject.Infrastructure.Exceptions;
using PetProject.Infrastructure.Logging;

namespace PetProject.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionsMiddleware>();
        services.AddPostgres();

        services.AddCustomLogging();
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionsMiddleware>();

        return app;
    }
}