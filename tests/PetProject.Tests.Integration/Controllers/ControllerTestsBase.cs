using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PetProject.Application.DTO;
using PetProject.Application.Security;
using PetProject.Infrastructure.Auth;
using PetProject.Infrastructure.Time;

namespace PetProject.Tests.Integration.Controllers;

[Collection("api")]
public abstract class ControllerTestsBase : IClassFixture<OptionsProvider>
{
    private readonly IAuthenticator _auth;
    protected HttpClient Client { get; }

    protected JwtDto Auth(Guid userId, string role)
    {
        var jwt =_auth.CreateToken(userId, role);
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.AccessToken);
        
        return jwt;
    }
        
    public ControllerTestsBase(OptionsProvider optionsProvider)
    {
        var authOptions = optionsProvider.Get<AuthOptions>("auth");
        _auth = new Authenticator(new OptionsWrapper<AuthOptions>(authOptions), new Clock());
        
        var app = new PetProjectTestApp(ConfigureServices);
        Client = app.Client;
    }

    protected virtual void ConfigureServices(IServiceCollection services)
    {
        
    }
}