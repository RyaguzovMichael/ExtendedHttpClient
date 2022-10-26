using ExtendedHttpClient.Extensions;
using ExtendedHttpClientUsageExample;
using ExtendedHttpClientUsageExample.Services;
using ExtendedHttpClientUsageExample.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddHttpClient();
services.AddServiceWithExtendedHttpClient<IServiceWithInterface, ServiceWithInterface>(configuration["ApiSettings:ServiceWithInterfaceUrl"]);
services.AddServiceWithExtendedHttpClient<SimpleService>(configuration["ApiSettings:SimpleServiceUrl"]);


var app = builder.Build();

app.UseMiddleware<CommonMiddleware>();

app.Map("/", async context => { await context.Response.WriteAsync(""); });

app.Run();
