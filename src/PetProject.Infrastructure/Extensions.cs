using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Application.Abstractions;
using PetProject.Application.DTO;
using PetProject.Application.Queries;
using PetProject.Core.Abstractions;
using PetProject.Infrastructure.Auth;
using PetProject.Infrastructure.DAL;
using PetProject.Infrastructure.Exceptions;
using PetProject.Infrastructure.Handlers;
using PetProject.Infrastructure.Logging;
using PetProject.Infrastructure.Security;
using PetProject.Infrastructure.Time;

namespace PetProject.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.Configure<AppOptions>(configuration.GetRequiredSection("app"));
        services.AddSingleton<ExceptionsMiddleware>();
        services.AddSecurity();
        services.AddAuth(configuration);
        services.AddHttpContextAccessor();
        
        services
            .AddSingleton<IClock, Clock>()
            .AddPostgres(configuration);
        
        services.AddCustomLogging();
        
        // var assemblies = new[]
        // {
        //     typeof(Extensions).Assembly,
        //     typeof(IQueryHandler<,>).Assembly
        // };

        // services.Scan(s => s.FromAssemblies(assemblies)
        //         .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
        //         .AsImplementedInterfaces().WithScopedLifetime());

        services.AddScoped<IQueryHandler<GetEvents, IEnumerable<EventsDto>>, GetEventsHandler>();
        services.AddScoped<IQueryHandler<GetUser, UserDto>, GetUserHandler>();
        services.AddScoped<IQueryHandler<GetUsers, IEnumerable<UserDto>>, GetUsersHandler>();
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionsMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();

        return app;
    }
    
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetRequiredSection(sectionName);
        section.Bind(options);

        return options;
    }
}