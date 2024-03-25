using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Oakton;
using Wolverine;
using Wolverine.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ApplyOaktonExtensions();
builder.Host.UseWolverine();

builder.Services.AddTransient<IService, HelloEndpointService>();

var app = builder.Build();
app.MapWolverineEndpoints();


return await app.RunOaktonCommands(args);

public class HelloEndpoint
{
    [WolverineGet("/")]
    public static string Get() => "Hello.";
    
    [WolverinePost("/")]
    public static string Post(IService data) => "Hello.";
}

public interface IService
{
};

public class HelloEndpointService : IService
{
    
}