using Microsoft.EntityFrameworkCore;
using PetProject.Core.Entities;
using PetProject.Core.Repositories;
using PetProject.Core.ValueObjects;

namespace PetProject.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserRepository : IUserRepository
{
    private readonly DbSet<User> _users;

    public PostgresUserRepository(PetProjectDbContext dbContext)
    {
        _users = dbContext.Users;
    }

    public async Task<User> GetByUsernameAsync(Username username)
        => await _users.SingleOrDefaultAsync(x => x.Username == username);

    public async Task<Role> GetRoleByOwnerIdAsync(UserId ownerId)
    {
        var user = await _users.SingleOrDefaultAsync(x => x.UserId == ownerId);
        return user.Role;
    }

    public async Task<User> GetByUserIdAsync(UserId userId)
        => await _users.SingleOrDefaultAsync(x => x.UserId == userId);

    public async Task<UserId> GetUserIdByUsernameAsync(Username username)
    {
        var user = await _users.SingleOrDefaultAsync(x => x.Username == username);
        return user.UserId;
    }
}