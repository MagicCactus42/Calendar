using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetProject.Application.Abstractions;
using PetProject.Application.Commands;
using PetProject.Application.DTO;
using PetProject.Application.Queries;
using PetProject.Application.Security;

namespace PetProject.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly ICommandHandler<SignUp> _signUpCommandHandler;
    private readonly ICommandHandler<SignIn> _signInCommandHandler;
    private readonly IQueryHandler<GetUser, UserDto> _getUserQueryHandler;
    private readonly IQueryHandler<GetUsers, IEnumerable<UserDto>> _getUsersQueryHandler;
    private readonly ITokenStorage _tokenStorage;

    public UsersController(ICommandHandler<SignUp> signUpCommandHandler, ICommandHandler<SignIn> signInCommandHandler,
        IQueryHandler<GetUser, UserDto> getUserQueryHandler,
        IQueryHandler<GetUsers, IEnumerable<UserDto>> getUsersQueryHandler, ITokenStorage tokenStorage)
    {
        _signUpCommandHandler = signUpCommandHandler;
        _signInCommandHandler = signInCommandHandler;
        _getUserQueryHandler = getUserQueryHandler;
        _getUsersQueryHandler = getUsersQueryHandler;
        _tokenStorage = tokenStorage;
    }
    
    [Authorize(Policy = "is-owner")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<UserDto>> GetUser(Guid userId)
    {
        var user = await _getUserQueryHandler.HandleAsync(new GetUser { UserId = userId });
        if (user is null)
            return NotFound();

        return user;
    }
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> Get()
    {
        if (string.IsNullOrWhiteSpace(HttpContext.User.Identity?.Name))
            return BadRequest();

        var userId = Guid.Parse(HttpContext.User.Identity.Name);
        var user = await _getUserQueryHandler.HandleAsync(new GetUser {UserId = userId});
        if (user is null)
            return NotFound();

        return user;
    }
    
    [Authorize(Policy = "is-owner")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get([FromQuery] GetUsers query)
        => Ok(await _getUsersQueryHandler.HandleAsync(query));
    
    [HttpPost]
    public async Task<ActionResult> Post(SignUp command)
    {
        command = command with { UserId = Guid.NewGuid() };
        await _signUpCommandHandler.HandleAsync(command);
        return CreatedAtAction(nameof(Get), new {command.UserId}, null);
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("login")]
    public async Task<ActionResult<JwtDto>> Post(SignIn command)
    {
        await _signInCommandHandler.HandleAsync(command);
        var jwt = _tokenStorage.Get();
        return Ok(jwt);
    }
}