using ExtendedHttpClient;

namespace ExtendedHttpClientUsageExample;

public class UserExtendedHttpClient<T> : ExtendedHttpClient<T>
{
    public UserExtendedHttpClient(IHttpClientFactory httpClientFactory, HttpClientOptions<T> options) : base(httpClientFactory, options)
    {
    }
}