using Calendar.Core.Entities;
using Calendar.Core.ValueObjects;

namespace Calendar.Core.Repositories;

public interface IEventRepository
{
    Task AddAsync(Events events);
    Task UpdateAsync(Events events);
    Task RemoveAsync(Events events);
    Task<Events?> GetByIdAsync(EventId eventId);
    Task<IEnumerable<Events>> GetAllByUserIdAsync(UserId userId);
    Task<IEnumerable<Events>> GetAllAsync();
}