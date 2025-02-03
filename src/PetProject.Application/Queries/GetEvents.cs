using PetProject.Application.Abstractions;
using PetProject.Application.DTO;

namespace PetProject.Application.Queries;

public class GetEvents : IQuery<IEnumerable<EventsDto>>
{
    public Guid OwnerId { get; set; }
}