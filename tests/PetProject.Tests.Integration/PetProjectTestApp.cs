using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace PetProject.Tests.Integration;

internal class PetProjectTestApp : WebApplicationFactory<Program>
{
    public HttpClient Client { get; }

    public PetProjectTestApp(Action<IServiceCollection> services)
    {
        Client = base.WithWebHostBuilder(builder =>
        {
            if (services is not null)
            {
                builder.ConfigureServices(services);
            }
            
            builder.UseEnvironment("test");
        }).CreateClient();
    }
}