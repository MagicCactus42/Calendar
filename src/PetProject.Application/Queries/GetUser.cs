using PetProject.Application.Abstractions;
using PetProject.Application.DTO;

namespace PetProject.Application.Queries;

public class GetUser : IQuery<UserDto>
{
    public Guid UserId { get; set; }
}