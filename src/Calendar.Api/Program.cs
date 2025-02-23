using Calendar.Application;
using Calendar.Core;
using Calendar.Infrastructure;
using Calendar.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication()
    .AddCore()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

builder.UseSerilog();

var app = builder.Build();

app.UseInfrastructure();

app.MapControllers();

app.Run();