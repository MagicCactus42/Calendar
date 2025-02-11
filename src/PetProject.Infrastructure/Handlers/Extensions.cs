using PetProject.Application.DTO;
using PetProject.Core.Entities;

namespace PetProject.Infrastructure.Handlers;

public static class Extensions
{
    public static EventsDto AsDto(this Events entity)
        => new()
        {
            EventId = entity.EventId.Value,
            EventName = entity.EventName,
            EventDescription = entity.EventDescription,
            From = entity.From.Value,
            To = entity.To.Value,
            OwnerId = entity.OwnerId.Value
        };

    public static UserDto AsDto(this User entity)
        => new()
        {
            Id = entity.UserId,
            Email = entity.Email,
            Username = entity.Username
        };
}