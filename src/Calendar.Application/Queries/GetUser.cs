using Calendar.Application.Abstractions;
using Calendar.Application.DTO;

namespace Calendar.Application.Queries;

public class GetUser : IQuery<UserDto>
{
    public Guid UserId { get; set; }
}