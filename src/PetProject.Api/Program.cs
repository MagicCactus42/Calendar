using PetProject.Application;
using PetProject.Core;
using PetProject.Infrastructure;
using PetProject.Infrastructure.Logging;

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