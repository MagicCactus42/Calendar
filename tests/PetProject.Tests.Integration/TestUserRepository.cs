using PetProject.Core.Entities;
using PetProject.Core.Repositories;
using PetProject.Core.ValueObjects;

namespace PetProject.Tests.Integration;

internal class TestUserRepository : IUserRepository
{
    private readonly List<User> _users = new();
    public Task<User> GetByEmailAsync(Email email)
            => Task.FromResult(_users.SingleOrDefault(u => u.Email == email));

    public Task<User> GetByUsernameAsync(Username username)
        => Task.FromResult(_users.SingleOrDefault(u => u.Username == username));

    public Task<Role> GetRoleByOwnerIdAsync(UserId ownerId)
    {
        var user =  _users.SingleOrDefault(x => x.UserId == ownerId);
        
        return Task.FromResult(user?.Role);
    }

    public Task<User> GetByUserIdAsync(UserId userId)
        => Task.FromResult(_users.SingleOrDefault(u => u.UserId == userId));

    public Task<UserId> GetUserIdByUsernameAsync(Username username)
    {
        var user =  _users.SingleOrDefault(x => x.Username == username);
        return Task.FromResult(user?.UserId);
    }

    public Task AddAsync(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }
}