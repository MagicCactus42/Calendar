using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Application.Abstractions;
using PetProject.Core.Repositories;
using PetProject.Infrastructure.DAL.Decorators;
using PetProject.Infrastructure.DAL.Repositories;

namespace PetProject.Infrastructure.DAL;

internal static class Extensions
{
    private const string SectionName = "postgres";
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(SectionName);
        services.Configure<PostgresOptions>(section);
        var options = configuration.GetOptions<PostgresOptions>(SectionName);
        
        services.AddDbContext<PetProjectDbContext>(x => x.UseNpgsql(options.ConnectionString));
        services.AddScoped<IEventRepository, PostgresEventRepository>();
        services.AddScoped<IUserRepository, PostgresUserRepository>();
        services.AddScoped<IUnitOfWork, PostgresUnitOfWork>();
        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));
        services.AddHostedService<DatabaseInitializer>();

        return services;
    }
}