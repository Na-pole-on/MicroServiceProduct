using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Ocelot.json");
builder.Services.AddOcelot();

var app = builder.Build();

await app.UseOcelot();

app.Run();
