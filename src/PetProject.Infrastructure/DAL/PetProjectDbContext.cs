using Microsoft.EntityFrameworkCore;
using PetProject.Core.Entities;

namespace PetProject.Infrastructure.DAL;

internal sealed class PetProjectDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Events> Events { get; set; }
    public DbSet<ScheduledEvent> ScheduledEvents { get; set; }

    public PetProjectDbContext(DbContextOptions<PetProjectDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}