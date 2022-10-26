namespace ExtendedHttpClient;

public class ExtendedHttpClientOptions<T>
{
    public string Url { get; private set; }

    public ExtendedHttpClientOptions(string url)
    {
        Url = url;
    }
}
