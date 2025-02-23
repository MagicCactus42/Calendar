using Calendar.Application.Abstractions;
using Calendar.Application.DTO;
using Calendar.Application.Queries;
using Calendar.Core.Abstractions;
using Calendar.Core.ValueObjects;
using Calendar.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;


namespace Calendar.Infrastructure.Handlers;

internal sealed class GetEventsHandler : IQueryHandler<GetEvents, IEnumerable<EventsDto>>
{
    private readonly CalendarDbContext _context;
    private readonly IClock _clock;

    public GetEventsHandler(CalendarDbContext context, IClock clock)
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