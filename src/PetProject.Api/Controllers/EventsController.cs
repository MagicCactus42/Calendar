using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetProject.Application.Abstractions;
using PetProject.Application.Commands;
using PetProject.Application.DTO;
using PetProject.Application.Queries;

namespace PetProject.Api.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly ICommandHandler<CreateEvent> _createEvent;
        private readonly IQueryHandler<GetEvents, IEnumerable<EventsDto>> _getEvents;
        private readonly ICommandHandler<RemoveEvent> _removeEvent;
        private readonly ICommandHandler<ChangeEvent> _changeEvent;

        public EventsController(ICommandHandler<CreateEvent> createEvent, IQueryHandler<GetEvents,
            IEnumerable<EventsDto>> getEvents, ICommandHandler<RemoveEvent> removeEvent, ICommandHandler<ChangeEvent> changeEvent)
        {
            _createEvent = createEvent;
            _getEvents = getEvents;
            _removeEvent = removeEvent;
            _changeEvent = changeEvent;
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult> Post(CreateEvent command)
        {
            var ownerId = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(ownerId))
                return Unauthorized();
            
            command = command with { OwnerId = Guid.Parse(ownerId) };
            await _createEvent.HandleAsync(command);
            return NoContent();
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public async Task<ActionResult> Put(ChangeEvent command)
        {
            var ownerId = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(ownerId))
                return Unauthorized();
            
            command = command with { OwnerId = Guid.Parse(ownerId) };
            await _changeEvent.HandleAsync(command);
            return NoContent();
        }
        
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventsDto>>> Get()
        {
            var ownerId = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(ownerId))
                return Unauthorized();
            
            var query = new GetEvents() { OwnerId = Guid.Parse(ownerId) };
            var result = await _getEvents.HandleAsync(query);
            return Ok(result);
        }
        
        [Authorize(Roles = "owner")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<EventsDto>>> GetUser(Guid id)
        {
            var query = new GetEvents() { OwnerId = id };
            var result = await _getEvents.HandleAsync(query);
            return Ok(result);
        }
        
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _removeEvent.HandleAsync(new RemoveEvent(id));
            return NotFound();
        }
        
    }
}
