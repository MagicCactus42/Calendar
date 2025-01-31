using Microsoft.Extensions.DependencyInjection;
using PetProject.Application.Abstractions;
using PetProject.Application.Commands;
using PetProject.Application.Commands.Handlers;

namespace PetProject.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateEvent>, CreateEventHandler>();
        
        return services;
    }
}