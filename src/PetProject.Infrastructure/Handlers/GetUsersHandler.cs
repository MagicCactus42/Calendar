using Microsoft.EntityFrameworkCore;
using PetProject.Application.Abstractions;
using PetProject.Application.DTO;
using PetProject.Application.Queries;
using PetProject.Infrastructure.DAL;

namespace PetProject.Infrastructure.Handlers;

internal sealed class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
{
    private readonly PetProjectDbContext _dbContext;

    public GetUsersHandler(PetProjectDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
        => await _dbContext.Users
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();

}