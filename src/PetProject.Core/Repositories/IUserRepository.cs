using PetProject.Core.Entities;
using PetProject.Core.ValueObjects;

namespace PetProject.Core.Repositories;

public interface IUserRepository
{
    Task<User> GetByUsernameAsync(Username username);
    Task<Role> GetRoleByOwnerIdAsync(UserId ownerId);
    Task<User> GetByUserIdAsync(UserId userId);
    Task<UserId> GetUserIdByUsernameAsync(Username username);
}