using Calendar.Core.Entities;
using Calendar.Core.ValueObjects;

namespace Calendar.Core.Repositories;

#nullable enable
public interface IUserRepository
{
    Task<User?> GetByEmailAsync(Email email);
    Task<User?> GetByUsernameAsync(Username username);
    Task<Role?> GetRoleByOwnerIdAsync(UserId ownerId);
    Task<User?> GetByUserIdAsync(UserId userId);
    Task<UserId?> GetUserIdByUsernameAsync(Username username);
    Task AddAsync(User user);
}