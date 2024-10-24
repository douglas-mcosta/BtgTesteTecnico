using BTG.Clientes.API.Configuration;
using BTG.WebAPI.Core.Identidate;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.ResolveDependencies();
var app = builder.Build();

app.UseApiConfiguration();

app.Run();
