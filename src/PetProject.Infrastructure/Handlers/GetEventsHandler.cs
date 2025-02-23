using Microsoft.EntityFrameworkCore;
using PetProject.Application.Abstractions;
using PetProject.Application.DTO;
using PetProject.Application.Queries;
using PetProject.Core.Abstractions;
using PetProject.Core.ValueObjects;
using PetProject.Infrastructure.DAL;

namespace PetProject.Infrastructure.Handlers;

internal sealed class GetEventsHandler : IQueryHandler<GetEvents, IEnumerable<EventsDto>>
{
    private readonly PetProjectDbContext _context;
    private readonly IClock _clock;

    public GetEventsHandler(PetProjectDbContext context, IClock clock)
    {
        _context = context;
        _clock = clock;
    }

    public async Task<IEnumerable<EventsDto>> HandleAsync(GetEvents query)
    {
        var ownerId = query.OwnerId;
        var events = await _context.Events
            .Where(x => x.OwnerId == (UserId)ownerId && x.To > _clock.Current())
            .AsNoTracking().ToListAsync();

        return events.Select(x => x.AsDto());
    }
}