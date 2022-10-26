using ExtendedHttpClient.Interfaces;

namespace ExtendedHttpClientUsageExample.Services.Interfaces
{
    public interface IServiceWithInterface : IUseExtendedHttpClient<IServiceWithInterface>
    {
    }
}
