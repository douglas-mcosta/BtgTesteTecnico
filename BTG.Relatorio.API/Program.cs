using BTG.Relatorio.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.ResolveDependencies(builder.Configuration);
var app = builder.Build();

app.UseApiConfiguration();


app.Run();
