using Microsoft.EntityFrameworkCore;
using PetProject.Core.Entities;
using PetProject.Core.Repositories;
using PetProject.Core.ValueObjects;

namespace PetProject.Infrastructure.DAL.Repositories;

internal sealed class PostgresEventRepository : IEventRepository
{
    private readonly PetProjectDbContext _dbContext;

    public PostgresEventRepository(PetProjectDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddAsync(Events events)
    {
        _dbContext.Events.Add(events);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(Events events)
    {
        _dbContext.Events.Remove(events);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Events?> GetByIdAsync(EventId eventId)
        => await _dbContext.Events.SingleOrDefaultAsync(x => x.EventId == eventId);

    public async Task<IEnumerable<Events>> GetAllAsync(UserId userId)
        => await _dbContext.Events.Include(x => x.OwnerId == userId).ToListAsync();
    
}