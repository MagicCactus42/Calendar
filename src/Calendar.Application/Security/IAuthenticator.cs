using Calendar.Application.DTO;

namespace Calendar.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string role);
}