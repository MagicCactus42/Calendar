using Calendar.Application.Abstractions;
using Calendar.Application.Commands;
using Calendar.Application.Commands.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Calendar.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // var applicationAssembly = typeof(ICommandHandler<>).Assembly;
        //
        // services.Scan(s => s.FromAssemblies(applicationAssembly)
        //     .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
        //     .AsImplementedInterfaces()
        //     .WithScopedLifetime());
        // TODO: make scrutor work

        
        services.AddScoped<ICommandHandler<CreateEvent>, CreateEventHandler>();
        services.AddScoped<ICommandHandler<SignUp>, SignUpHandler>();
        services.AddScoped<ICommandHandler<SignIn>, SignInHandler>();
        services.AddScoped<ICommandHandler<RemoveEvent>, RemoveEventHandler>();
        services.AddScoped<ICommandHandler<ChangeEvent>, ChangeEventHandler>();
        
        return services;
    }
}