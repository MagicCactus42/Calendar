using Microsoft.EntityFrameworkCore;
using Calendar.Application.Abstractions;
using Calendar.Application.DTO;
using Calendar.Application.Queries;
using Calendar.Infrastructure.DAL;

namespace Calendar.Infrastructure.Handlers;

internal sealed class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
{
    private readonly CalendarDbContext _dbContext;

    public GetUsersHandler(CalendarDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
        => await _dbContext.Users
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();

}