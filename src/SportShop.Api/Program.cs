using Microsoft.Extensions.Options;
using Serilog;
using SportShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog((context, LoggerConfiguration) =>
{
    LoggerConfiguration.WriteTo
    .Console();
});

var app = builder.Build();
app.UseInfrastructure();
app.MapGet("api", (IOptions<AppOptions> options) => Results.Ok(options.Value.Name));
app.Run();
