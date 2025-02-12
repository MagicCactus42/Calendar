using PetProject.Application.Abstractions;
using PetProject.Application.Exceptions;
using PetProject.Core.Repositories;

namespace PetProject.Application.Commands.Handlers;

internal sealed class RemoveEventHandler : ICommandHandler<RemoveEvent>
{
    private readonly IEventRepository _eventRepository;

    public RemoveEventHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    public async Task HandleAsync(RemoveEvent command)
    {
        var eventToRemove = await _eventRepository.GetByIdAsync(command.EventId);
        if (eventToRemove is null)
            throw new EventNotFoundException(command.EventId);
        
        eventToRemove.RemoveEvent(command.EventId);
        await _eventRepository.UpdateAsync(eventToRemove);
    }
}