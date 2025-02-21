using System.Net;
using FluentAssertions;

namespace PetProject.Tests.Integration.Controllers;

public class HomeControllerTests : ControllerTestsBase
{
    public HomeControllerTests(OptionsProvider optionsProvider) : base(optionsProvider)
    {
    }

    [Fact]
    public async Task home_controller_get_should_return_200_ok_and_api_name()
    {
        var response = await Client.GetAsync("/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNull();
        content.Should().Be("PetProject Api [testEnv]");
    }
}