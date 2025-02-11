using Microsoft.AspNetCore.Mvc;
using PetProject.Application.Abstractions;
using PetProject.Application.Commands;
using PetProject.Application.DTO;
using PetProject.Application.Queries;

namespace PetProject.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ICommandHandler<SignUp> _signUpCommandHandler;
    private readonly IQueryHandler<GetUser, UserDto> _getUserQueryHandler;
    private readonly IQueryHandler<GetUsers, IEnumerable<UserDto>> _getUsersQueryHandler;

    public UsersController(ICommandHandler<SignUp> signUpCommandHandler,
        IQueryHandler<GetUser, UserDto> getUserQueryHandler,
        IQueryHandler<GetUsers, IEnumerable<UserDto>> getUsersQueryHandler)
    {
        _signUpCommandHandler = signUpCommandHandler;
        _getUserQueryHandler = getUserQueryHandler;
        _getUsersQueryHandler = getUsersQueryHandler;
    }

    
    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> Get()
    {
        var userId = Guid.Parse(User.Identity?.Name);
        var user = await _getUserQueryHandler.HandleAsync(new GetUser {UserId = userId});

        return user;
    }
    
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
}