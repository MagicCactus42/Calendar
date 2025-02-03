using Microsoft.AspNetCore.Mvc;
using PetProject.Application.Abstractions;
using PetProject.Application.Commands;
using PetProject.Application.DTO;
using PetProject.Application.Queries;

namespace PetProject.Api.Controllers
{
    [ApiController]
    [Route("api/event")]
    public class EventsController : ControllerBase
    {
        private readonly ICommandHandler<CreateEvent> _createEvent;
        private readonly IQueryHandler<GetEvents, IEnumerable<EventsDto>> _getEvents;

        public EventsController(ICommandHandler<CreateEvent> createEvent, IQueryHandler<GetEvents, IEnumerable<EventsDto>> getEvents)
        {
            _createEvent = createEvent;
            _getEvents = getEvents;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Post(CreateEvent command)
        {
            command = command with { OwnerId = Guid.NewGuid() }; // Na potrzeby testowania dopóki nie zaimplementuje auth
            await _createEvent.HandleAsync(command);
            // return NoContent();
            return Ok(command.OwnerId); // Na potrzeby testowania dopóki nie zaimplementuje auth
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<IEnumerable<EventsDto>>> Get(Guid id)
        {
            var query = new GetEvents() { OwnerId = id };
            var result = await _getEvents.HandleAsync(query);
            return Ok(result);
        }
        
    }
}
