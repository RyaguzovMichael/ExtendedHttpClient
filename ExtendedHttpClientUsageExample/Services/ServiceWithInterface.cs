using ExtendedHttpClient;
using ExtendedHttpClientUsageExample.Services.Interfaces;

namespace ExtendedHttpClientUsageExample.Services;

public class ServiceWithInterface : IServiceWithInterface
{
    public ExtendedHttpClient<IServiceWithInterface> ExtendedHttpClient { get; set; }

    public ServiceWithInterface(ExtendedHttpClient<IServiceWithInterface> httpClient)
    {
        ExtendedHttpClient = httpClient;
    }
}
