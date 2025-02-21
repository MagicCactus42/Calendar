using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Application.Commands;
using PetProject.Application.DTO;
using PetProject.Core.Entities;
using PetProject.Core.Repositories;
using PetProject.Core.ValueObjects;
using PetProject.Infrastructure.Security;
using PetProject.Infrastructure.Time;

namespace PetProject.Tests.Integration.Controllers;

public class UsersControllerTests : ControllerTestsBase, IDisposable, IAsyncDisposable
{
    [Fact]
    public async Task post_users_should_return_201_created()
    {
        var command = new SignUp(Guid.Empty, "testuser1@proton.me",
            "testpassword", "testuser1", Role.User());
        
        var response = await Client.PostAsJsonAsync("Users", command);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
        response.Headers.Location.Should().NotBeNull();
    }

    [Fact]
    public async Task post_users_sign_in_should_return_200_ok_and_jwt()
    {
        var user = await CreateUserInMemory();

        var command = new SignIn(user.Email, Password);
        var response = await Client.PostAsJsonAsync("Users/sign-in", command);
        
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var jwt = await response.Content.ReadFromJsonAsync<JwtDto>();
        jwt.Should().NotBeNull();
        jwt.AccessToken.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task get_users_me_should_return_200_ok_and_user()
    {
        var user = await CreateUserAsync();

        Auth(user.UserId, user.Role);

        var userDto = await Client.GetFromJsonAsync<UserDto>("Users/me");
        userDto.Should().NotBeNull();
        userDto.Email.Should().Be(user.Email);
    }


    #region arrange

    private async Task<User> CreateUserAsync()
    {
        var clock = new Clock();
        var passwordManager = new PasswordManager(new PasswordHasher<User>());
        const string password = Password;
        var user = new User(Guid.NewGuid(), "testuser1@proton.me", passwordManager.Secure(password), "testuser1", clock.Current().UtcDateTime ,Role.User());

        await _testDatabase.DbContext.Users.AddAsync(user);
        await _testDatabase.DbContext.SaveChangesAsync();

        return user;
    }

    private async Task<User> CreateUserInMemory()
    {
        var clock = new Clock();
        var passwordManager = new PasswordManager(new PasswordHasher<User>());
        const string password = Password;
        var user = new User(Guid.NewGuid(), "testuser1@proton.me", passwordManager.Secure(password), "testuser1", clock.Current().UtcDateTime ,Role.User());

        await _userRepository.AddAsync(user);

        return user;
    }
    
    private const string Password = "testpassword";
    private readonly TestDatabase _testDatabase;
    private IUserRepository _userRepository;

    public UsersControllerTests(OptionsProvider optionsProvider) : base(optionsProvider)
    {
        _testDatabase = new TestDatabase();
    }

    public void Dispose()
    {
        _testDatabase.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _testDatabase.DisposeAsync();
    }

    protected override void ConfigureServices(IServiceCollection services)
    {
        _userRepository = new TestUserRepository();
        services.AddSingleton(_userRepository);
    }

    #endregion
    
}