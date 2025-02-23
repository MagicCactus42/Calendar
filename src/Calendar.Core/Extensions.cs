using Calendar.Core.DomainServices;
using Calendar.Core.Policies;
using Microsoft.Extensions.DependencyInjection;

namespace Calendar.Core;

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