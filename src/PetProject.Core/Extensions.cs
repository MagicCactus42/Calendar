using Microsoft.Extensions.DependencyInjection;
using PetProject.Core.DomainServices;
using PetProject.Core.Policies;

namespace PetProject.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IEventPolicy, OwnerEventPolicy>();
        services.AddSingleton<IEventPolicy, RegularUserPolicy>();
        services.AddSingleton<IEventDomainService, EventDomainService>();
        
        return services;
    }
}