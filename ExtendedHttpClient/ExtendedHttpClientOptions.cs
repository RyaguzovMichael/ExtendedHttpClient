namespace ExtendedHttpClient;

public class ExtendedHttpClientOptions<T>
{
    private readonly string? _url;
    public Action<HttpClient> Options { get; }

    public ExtendedHttpClientOptions(string url)
    {
        _url = url!;
        Options = SetDefaultHttpClientOptions;
    }

    public ExtendedHttpClientOptions(Action<HttpClient> options)
    {
        Options = options;
    }

    private void SetDefaultHttpClientOptions(HttpClient client)
    {
        client.BaseAddress = new Uri(_url!);
        client.Timeout = TimeSpan.FromSeconds(5);
    }
    
}
