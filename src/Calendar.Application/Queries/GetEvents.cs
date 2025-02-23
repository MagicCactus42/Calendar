using Calendar.Application.Abstractions;
using Calendar.Application.DTO;

namespace Calendar.Application.Queries;

public class GetEvents : IQuery<IEnumerable<EventsDto>>
{
    public Guid OwnerId { get; set; }
}