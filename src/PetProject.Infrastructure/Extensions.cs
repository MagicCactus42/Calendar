using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Application.Abstractions;
using PetProject.Application.DTO;
using PetProject.Application.Queries;
using PetProject.Infrastructure.DAL;
using PetProject.Infrastructure.Exceptions;
using PetProject.Infrastructure.Handlers;
using PetProject.Infrastructure.Logging;

namespace PetProject.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionsMiddleware>();
        services.AddPostgres();
        
        // var assemblies = new[]
        // {
        //     typeof(Extensions).Assembly,
        //     typeof(IQueryHandler<,>).Assembly
        // };

        // services.Scan(s => s.FromAssemblies(assemblies)
        //         .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
        //         .AsImplementedInterfaces().WithScopedLifetime());

        services.AddScoped<IQueryHandler<GetEvents, IEnumerable<EventsDto>>, GetEventsHandler>();
        
        services.AddCustomLogging();
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionsMiddleware>();

        return app;
    }
}