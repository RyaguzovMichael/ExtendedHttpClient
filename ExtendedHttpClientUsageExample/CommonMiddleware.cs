using ExtendedHttpClientUsageExample.Services;
using ExtendedHttpClientUsageExample.Services.Interfaces;

namespace ExtendedHttpClientUsageExample;

public class CommonMiddleware
{
    private readonly RequestDelegate _next;

    public CommonMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IServiceWithInterface serviceWithInterface, SimpleService simpleService)
    {
        await _next.Invoke(context);

        await context.Response.WriteAsync($"Service URI with interface: {serviceWithInterface.ExtendedHttpClient.HttpClient.BaseAddress}\n" +
                                          $"Service URI without interface: {simpleService.ExtendedHttpClient.HttpClient.BaseAddress}\n");
    }
}
