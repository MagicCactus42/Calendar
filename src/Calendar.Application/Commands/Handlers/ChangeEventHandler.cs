using Calendar.Application.Abstractions;
using Calendar.Application.Exceptions;
using Calendar.Core.Repositories;

namespace Calendar.Application.Commands.Handlers;

public sealed class ChangeEventHandler : ICommandHandler<ChangeEvent>
{
    private readonly IEventRepository _eventRepository;

    public ChangeEventHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    
    public async Task HandleAsync(ChangeEvent command)
    {
        var eventToUpdate = await _eventRepository.GetByIdAsync(command.EventId);
        if (eventToUpdate is null)
            throw new EventNotFoundException(command.EventId);
        
        eventToUpdate.ChangeEvent(command.EventName, command.EventDescription, command.From, command.To, command.CanOverlap);
        await _eventRepository.UpdateAsync(eventToUpdate);
     }
}