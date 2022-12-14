using ExtendedHttpClient.Extensions;
using ExtendedHttpClientUsageExample;
using ExtendedHttpClientUsageExample.Services;
using ExtendedHttpClientUsageExample.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddExtendedHttpClient(typeof(UserExtendedHttpClient<>));
services.AddServiceWithExtendedHttpClient<IServiceWithInterface, ServiceWithInterface>(configuration["ApiSettings:ServiceWithInterfaceUrl"]);
services.AddServiceWithExtendedHttpClient<SimpleService>(options =>
{
    options.BaseAddress = new Uri(configuration["ApiSettings:SimpleServiceUrl"]);
});


var app = builder.Build();

app.UseMiddleware<CommonMiddleware>();

app.Map("/", async context => { await context.Response.WriteAsync(""); });

app.Run();
