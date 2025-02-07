using PetProject.Application.Abstractions;
using PetProject.Application.Exceptions;
using PetProject.Core.DomainServices;
using PetProject.Core.Entities;
using PetProject.Core.Repositories;
using PetProject.Core.ValueObjects;

namespace PetProject.Application.Commands.Handlers;

public class CreateEventHandler : ICommandHandler<CreateEvent>
{
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEventDomainService _eventDomainService;

    public CreateEventHandler(IEventRepository eventRepository, IEventDomainService eventDomainService, IUserRepository userRepository)
    {
        _eventRepository = eventRepository;
        _eventDomainService = eventDomainService;
        _userRepository = userRepository;
    }

    public async Task HandleAsync(CreateEvent command)
    {
        var role = await _userRepository.GetRoleByOwnerIdAsync(command.OwnerId);
        
        var events = (await _eventRepository.GetAllAsync(command.OwnerId)).ToList();

        var user = await _userRepository.GetByUserIdAsync(command.OwnerId);
        if (user is null)
            throw new UserNotFoundException(command.OwnerId);
        
        var newEvent = new Events(Guid.NewGuid(), command.EventName,
            command.EventDescription, true, command.From, command.To, command.OwnerId, command.CanOverlap);
        
        _eventDomainService.CreateEventService(newEvent, role, events);
        await _eventRepository.UpdateAsync(newEvent);
    }
}