using ExtendedHttpClientUsageExample.Services;
using ExtendedHttpClientUsageExample.Services.Interfaces;

namespace ExtendedHttpClientUsageExample;

public class CommonMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceWithInterface _serviceWithInterface;
    private readonly SimpleService _simpleService;

    public CommonMiddleware(RequestDelegate next, IServiceWithInterface service, SimpleService requestService)
    {
        _next = next;
        _serviceWithInterface = service;
        _simpleService = requestService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next.Invoke(context);

        await context.Response.WriteAsync($"Service URI with interface: {_serviceWithInterface.ExtendedHttpClient.HttpClient.BaseAddress}\n" +
                                          $"Service URI without interface: {_simpleService.ExtendedHttpClient.HttpClient.BaseAddress}\n");
    }
}
