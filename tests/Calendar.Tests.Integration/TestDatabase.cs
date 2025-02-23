using Calendar.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Tests.Integration;

internal class TestDatabase : IDisposable, IAsyncDisposable
{
    public CalendarDbContext DbContext { get; }

    public TestDatabase()
    {
        var options = new OptionsProvider().Get<PostgresOptions>("postgres");
        DbContext = new CalendarDbContext(
            new DbContextOptionsBuilder<CalendarDbContext>().UseNpgsql(options.ConnectionString).Options);
    }

    public void Dispose()
    {
        DbContext.Database.EnsureDeleted();
        DbContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await DbContext.Database.EnsureDeletedAsync();
        await DbContext.DisposeAsync();
    }
}