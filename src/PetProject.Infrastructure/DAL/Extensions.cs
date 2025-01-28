using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Core.Repositories;
using PetProject.Infrastructure.DAL.Repositories;

namespace PetProject.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        const string connectionString =
            "Host=localhost;Port=5433;Database=postgresDatabase;Username=postgres0;Password=password123";

        services.AddDbContext<PetProjectDbContext>(x => x.UseNpgsql(connectionString));

        services.AddScoped<IEventRepository, PostgresEventRepository>();

        return services;
    }
}