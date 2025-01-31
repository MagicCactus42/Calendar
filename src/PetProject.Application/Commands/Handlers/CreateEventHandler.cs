using PetProject.Application.Abstractions;
using PetProject.Core.Entities;
using PetProject.Core.Repositories;

namespace PetProject.Application.Commands.Handlers;

public class CreateEventHandler : ICommandHandler<CreateEvent>
{
    private readonly IEventRepository _eventRepository;

    public CreateEventHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task HandleAsync(CreateEvent command)
    {
        var newEvent = new Events(Guid.NewGuid(), command.EventName,
            command.EventDescription, true, command.From, command.To, command.OwnerId);
        
        // dodac pozniej domain service 
        await _eventRepository.AddAsync(newEvent);
    }
}