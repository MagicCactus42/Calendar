using PetProject.Application;
using PetProject.Core;
using PetProject.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication()
    .AddCore()
    .AddInfrastructure()
    .AddControllers();

var app = builder.Build();
app.Run();