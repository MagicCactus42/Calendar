using Calendar.Core.Abstractions;
using Calendar.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Calendar.Infrastructure.DAL;

internal sealed class DatabaseInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IClock _clock;

    public DatabaseInitializer(IServiceProvider serviceProvider, IClock clock)
    {
        _serviceProvider = serviceProvider;
        _clock = clock;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CalendarDbContext>();
        await dbContext.Database.MigrateAsync(cancellationToken);

        if (await dbContext.Events.AnyAsync(cancellationToken))
        {
            return;
        }

        var allEvents = new List<Events>()
        {
            Events.Create("Test Event", "This is a test event", _clock.Current(), _clock.Current().AddYears(100))
        };
        await dbContext.Events.AddRangeAsync(allEvents, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}