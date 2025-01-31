using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Application.Abstractions;
using PetProject.Infrastructure.Logging.Decorators;
using Serilog;

namespace PetProject.Infrastructure.Logging;

public static class Extensions
{
    internal static IServiceCollection AddCustomLogging(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

        return services;
    }

    public static WebApplicationBuilder UseSerilog(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.WriteTo
                .Console()
                .WriteTo
                .File("logs/logs.txt")
                .WriteTo
                .Seq("http://localhost:5340");
            
            
        });
        
        return builder;
    }
    
}