using PetProject.Application.DTO;

namespace PetProject.Application.Security;

public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();
}