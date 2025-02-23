using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Calendar.Application.Abstractions;
using Calendar.Core.Repositories;
using Calendar.Infrastructure.DAL.Decorators;
using Calendar.Infrastructure.DAL.Repositories;

namespace Calendar.Infrastructure.DAL;

internal static class Extensions
{
    private const string SectionName = "postgres";
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresOptions>(configuration.GetRequiredSection(SectionName));
        var options = configuration.GetOptions<PostgresOptions>(SectionName);
        
        services.AddDbContext<CalendarDbContext>(x => x.UseNpgsql(options.ConnectionString));
        services.AddScoped<IEventRepository, PostgresEventRepository>();
        services.AddScoped<IUserRepository, PostgresUserRepository>();
        services.AddHostedService<DatabaseInitializer>();
        services.AddScoped<IUnitOfWork, PostgresUnitOfWork>();
        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

        return services;
    }
}