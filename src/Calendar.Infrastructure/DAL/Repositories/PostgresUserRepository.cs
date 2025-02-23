using Calendar.Core.Entities;
using Calendar.Core.Repositories;
using Calendar.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Infrastructure.DAL.Repositories;

#nullable enable
internal sealed class PostgresUserRepository : IUserRepository
{
    private readonly DbSet<User> _users;

    public PostgresUserRepository(CalendarDbContext dbContext)
    {
        _users = dbContext.Users;
    }

    public Task<User?> GetByEmailAsync(Email email)
        => _users.AsNoTracking().SingleOrDefaultAsync(x => x.Email == email);
    
    public Task<User?> GetByUsernameAsync(Username username)
        => _users.AsNoTracking().SingleOrDefaultAsync(x => x.Username == username);
    
    public Task<User?> GetByUserIdAsync(UserId userId)
        => _users.AsNoTracking().SingleOrDefaultAsync(x => x.UserId == userId);
    
    public async Task<Role?> GetRoleByOwnerIdAsync(UserId ownerId)
    {
        var user = await _users.AsNoTracking().SingleOrDefaultAsync(x => x.UserId == ownerId);
        
        return user?.Role;
    }

    public async Task<UserId?> GetUserIdByUsernameAsync(Username username)
    {
        var user = await _users.AsNoTracking().SingleOrDefaultAsync(x => x.Username == username);
        return user?.UserId;
    }
    
    public async Task AddAsync(User user)
        => await _users.AddAsync(user);
}