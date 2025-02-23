using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Calendar.Tests.Integration;

internal class CalendarTestApp : WebApplicationFactory<Program>
{
    public HttpClient Client { get; }

    public CalendarTestApp(Action<IServiceCollection> services)
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