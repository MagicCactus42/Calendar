using PetProject.Application.DTO;

namespace PetProject.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string role);
}