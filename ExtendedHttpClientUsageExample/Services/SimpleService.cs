using ExtendedHttpClient;
using ExtendedHttpClient.Interfaces;

namespace ExtendedHttpClientUsageExample.Services
{
    public class SimpleService : IUseExtendedHttpClient<SimpleService>
    {
        public ExtendedHttpClient<SimpleService> ExtendedHttpClient { get; set; }

        public SimpleService(ExtendedHttpClient<SimpleService> extendedHttpClient)
        {
            ExtendedHttpClient = extendedHttpClient;
        }
    }
}
