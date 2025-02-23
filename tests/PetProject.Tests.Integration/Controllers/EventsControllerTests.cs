using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PetProject.Core.Entities;
using PetProject.Core.Repositories;
using PetProject.Core.ValueObjects;
using PetProject.Infrastructure.Security;
using PetProject.Infrastructure.Time;

namespace PetProject.Tests.Integration.Controllers;

public class EventsControllerTests : ControllerTestsBase, IDisposable, IAsyncDisposable
{

    // TODO: add Events Controller Tests
    
    #region arrange

    private async Task<User> CreateUserAsync()
    {
        var clock = new Clock();
        var passwordManager = new PasswordManager(new PasswordHasher<User>());
        const string password = Password;
        var user = new User(Guid.NewGuid(), "testuser1@proton.me", passwordManager.Secure(password), "testuser1", clock.Current().UtcDateTime , Role.User());

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

    public EventsControllerTests(OptionsProvider optionsProvider) : base(optionsProvider)
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