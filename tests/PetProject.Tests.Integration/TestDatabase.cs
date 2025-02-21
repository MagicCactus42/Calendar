using Microsoft.EntityFrameworkCore;
using PetProject.Infrastructure.DAL;

namespace PetProject.Tests.Integration;

internal class TestDatabase : IDisposable, IAsyncDisposable
{
    public PetProjectDbContext DbContext { get; }

    public TestDatabase()
    {
        var options = new OptionsProvider().Get<PostgresOptions>("postgres");
        DbContext = new PetProjectDbContext(
            new DbContextOptionsBuilder<PetProjectDbContext>().UseNpgsql(options.ConnectionString).Options);
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