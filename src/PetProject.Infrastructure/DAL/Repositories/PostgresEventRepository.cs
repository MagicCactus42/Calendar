using Microsoft.EntityFrameworkCore;
using PetProject.Core.Entities;
using PetProject.Core.Repositories;
using PetProject.Core.ValueObjects;

namespace PetProject.Infrastructure.DAL.Repositories;

#nullable enable
internal sealed class PostgresEventRepository : IEventRepository
{
    private readonly PetProjectDbContext _dbContext;
    private readonly DbSet<Events> _events;

    public PostgresEventRepository(PetProjectDbContext dbContext)
    {
        _dbContext = dbContext;
        _events = _dbContext.Events;
    }
    
    public async Task AddAsync(Events events)
        => await _events.AddAsync(events);

    public Task UpdateAsync(Events events)
    {
        _events.Update(events);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Events events)
    {
        _events.Remove(events);
        return Task.CompletedTask;
    }
    

    public async Task<Events?> GetByIdAsync(EventId eventId)
        => await _events.SingleOrDefaultAsync(x => x.EventId == eventId);

    public async Task<IEnumerable<Events>> GetAllByUserIdAsync(UserId userId)
        => await _events.Where(x => x.OwnerId == userId).ToListAsync();

    public async Task<IEnumerable<Events>> GetAllAsync()
        => await _events.ToListAsync();
}