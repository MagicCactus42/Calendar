using Calendar.Application.DTO;

namespace Calendar.Application.Security;

public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();
}