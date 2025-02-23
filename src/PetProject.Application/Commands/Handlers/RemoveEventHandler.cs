using PetProject.Application.Abstractions;
using PetProject.Application.Exceptions;
using PetProject.Core.DomainServices;
using PetProject.Core.Entities;
using PetProject.Core.Repositories;

namespace PetProject.Application.Commands.Handlers;

internal sealed class RemoveEventHandler : ICommandHandler<RemoveEvent>
{
    private readonly IEventRepository _eventRepository;
    private readonly EventsEnumerable _events = new();

    public RemoveEventHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    public async Task HandleAsync(RemoveEvent command)
    {
        var eventToRemove = await _eventRepository.GetByIdAsync(command.EventId);
        if (eventToRemove is null)
            throw new EventNotFoundException(command.EventId);
        
        // _events.RemoveEvent(command.EventId);
        // await _eventRepository.UpdateAsync(eventToRemove);
        // TODO: change this \/ to this /\
        await _eventRepository.RemoveAsync(eventToRemove);
    }
}