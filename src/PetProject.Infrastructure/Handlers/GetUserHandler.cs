using Microsoft.EntityFrameworkCore;
using PetProject.Application.Abstractions;
using PetProject.Application.DTO;
using PetProject.Application.Queries;
using PetProject.Core.ValueObjects;
using PetProject.Infrastructure.DAL;

namespace PetProject.Infrastructure.Handlers;

internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDto>
{
    private readonly PetProjectDbContext _dbContext;

    public GetUserHandler(PetProjectDbContext dbContext)
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