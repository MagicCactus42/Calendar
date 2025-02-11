using PetProject.Core.Entities;
using PetProject.Core.ValueObjects;

namespace PetProject.Core.Repositories;

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