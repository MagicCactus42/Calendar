using Microsoft.Extensions.DependencyInjection;
using PetProject.Infrastructure.DAL;

namespace PetProject.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPostgres();
        
        return services;
    }
}