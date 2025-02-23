using Calendar.Application.Abstractions;
using Calendar.Application.Exceptions;
using Calendar.Core.DomainServices;
using Calendar.Core.Entities;
using Calendar.Core.Repositories;

namespace Calendar.Application.Commands.Handlers;

internal sealed class CreateEventHandler : ICommandHandler<CreateEvent>
{
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEventDomainService _eventDomainService;
    private readonly EventsEnumerable _events = new();

    public CreateEventHandler(IEventRepository eventRepository, IEventDomainService eventDomainService, IUserRepository userRepository)
    {
        _eventRepository = eventRepository;
        _eventDomainService = eventDomainService;
        _userRepository = userRepository;
    }

    public async Task HandleAsync(CreateEvent command)
    {
        var role = await _userRepository.GetRoleByOwnerIdAsync(command.OwnerId);
        
        var user = await _userRepository.GetByUserIdAsync(command.OwnerId);
        if (user is null)
            throw new UserNotFoundException(command.OwnerId);
        
        var newEvent = new Events(Guid.NewGuid(), command.EventName,
            command.EventDescription, true, command.From, command.To, command.OwnerId, command.CanOverlap);
        
        _eventDomainService.CreateEventService(newEvent, role, _events);
        await _eventRepository.AddAsync(newEvent);
    }
}