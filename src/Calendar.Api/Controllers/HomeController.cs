using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Calendar.Infrastructure;

namespace Calendar.Api.Controllers;

[Route("")]
public class HomeController : ControllerBase
{
    private readonly AppOptions _appOptions;

    public HomeController(IOptions<AppOptions> appOptions)
    {
        _appOptions = appOptions.Value;
    }
    
    [HttpGet]
    public ActionResult Get() => Ok(_appOptions.Name);
}