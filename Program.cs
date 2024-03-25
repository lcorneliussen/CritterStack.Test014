using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Oakton;
using Wolverine;
using Wolverine.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ApplyOaktonExtensions();
builder.Host.UseWolverine();

var app = builder.Build();
app.MapWolverineEndpoints();

return await app.RunOaktonCommands(args);

public class HelloEndpoint
{
    [WolverineGet("/")]
    public string Get() => "Hello.";
}