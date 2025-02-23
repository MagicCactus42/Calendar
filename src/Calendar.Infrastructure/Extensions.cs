using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Calendar.Application.Abstractions;
using Calendar.Application.DTO;
using Calendar.Application.Queries;
using Calendar.Core.Abstractions;
using Calendar.Infrastructure.Exceptions;
using Calendar.Infrastructure.Handlers;
using Calendar.Infrastructure.Time;
using Calendar.Infrastructure.Auth;
using Calendar.Infrastructure.DAL;
using Calendar.Infrastructure.Logging;
using Calendar.Infrastructure.Security;

namespace Calendar.Infrastructure;

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
        
        // var infrastructureAssembly = typeof(AppOptions).Assembly;
        //
        // services.Scan(s => s.FromAssemblies(infrastructureAssembly)
        //     .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
        //     .AsImplementedInterfaces()
        //     .WithScopedLifetime());
        // TODO: make scrutor work
        
        services.AddScoped<IQueryHandler<GetEvents, IEnumerable<EventsDto>>, GetEventsHandler>();
        services.AddScoped<IQueryHandler<GetUser, UserDto>, GetUserHandler>();
        services.AddScoped<IQueryHandler<GetUsers, IEnumerable<UserDto>>, GetUsersHandler>();
        
        services.AddCustomLogging();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(swagger =>
        {
            swagger.EnableAnnotations();
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Calendar API",
                Version = "v1",
            });
        });
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionsMiddleware>();
        app.UseSwagger();
        app.UseReDoc(reDoc =>
        {
            reDoc.RoutePrefix = "redoc";
            reDoc.SpecUrl("/swagger/v1/swagger.json");
            reDoc.DocumentTitle = "Calendar API";
        });
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