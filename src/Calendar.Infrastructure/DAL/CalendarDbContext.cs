using Calendar.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Infrastructure.DAL;

internal sealed class CalendarDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Events> Events { get; set; }

    public CalendarDbContext(DbContextOptions<CalendarDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}