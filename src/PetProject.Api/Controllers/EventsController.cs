using Microsoft.AspNetCore.Mvc;
using PetProject.Application.Abstractions;
using PetProject.Application.Commands;

namespace PetProject.Api.Controllers
{
    [ApiController]
    [Route("api/event")]
    public class EventsController : ControllerBase
    {
        private readonly ICommandHandler<CreateEvent> _createEvent;

        public EventsController(ICommandHandler<CreateEvent> createEvent)
        {
            _createEvent = createEvent;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Post(CreateEvent command)
        {
            command = command with { OwnerId = Guid.NewGuid() };
            await _createEvent.HandleAsync(command);
            return NoContent();
        }
    }
}
