using Microsoft.EntityFrameworkCore;
using Calendar.Application.Abstractions;
using Calendar.Application.DTO;
using Calendar.Application.Queries;
using Calendar.Core.ValueObjects;
using Calendar.Infrastructure.DAL;

namespace Calendar.Infrastructure.Handlers;

internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDto>
{
    private readonly CalendarDbContext _dbContext;

    public GetUserHandler(CalendarDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserDto> HandleAsync(GetUser query)
    {
        var userId = new UserId(query.UserId);
        var user = await _dbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.UserId == userId);

        return user?.AsDto();
    }
}