using ExtendedHttpClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExtendedHttpClient.Extensions;

public static class Extensions
{
    public static IServiceCollection AddServiceWithExtendedHttpClient<TClass>(this IServiceCollection services, string uri)
        where TClass : class, IUseExtendedHttpClient<TClass>
    {
        services.AddServiceWithExtendedHttpClient<TClass>(httpOptions => httpOptions.BaseAddress = new Uri(uri));
        return services;
    }
    
    public static IServiceCollection AddServiceWithExtendedHttpClient<TClass>(this IServiceCollection services, Action<HttpClient> httpOptions)
        where TClass : class, IUseExtendedHttpClient<TClass>
    {
        services.AddHttpClient();
        services.AddSingleton(provider => new HttpClientOptions<TClass>(httpOptions));
        services.AddTransient<ExtendedHttpClient<TClass>>();
        services.AddTransient<TClass>();

        return services;
    }
    
    public static IServiceCollection AddServiceWithExtendedHttpClient<TClass, TImplementation>(this IServiceCollection services, string uri)
        where TClass : class, IUseExtendedHttpClient<TClass>
        where TImplementation : class, TClass
    {
        services.AddServiceWithExtendedHttpClient<TClass, TImplementation>(httpOptions => httpOptions.BaseAddress = new Uri(uri));
        return services;
    }
    
    public static IServiceCollection AddServiceWithExtendedHttpClient<TClass, TImplementation>(this IServiceCollection services, Action<HttpClient> httpOptions)
        where TClass : class, IUseExtendedHttpClient<TClass>
        where TImplementation : class, TClass
    {
        services.AddHttpClient();
        services.AddSingleton(provider => new HttpClientOptions<TClass>(httpOptions));
        services.AddTransient<ExtendedHttpClient<TClass>>();
        services.AddTransient<TClass, TImplementation>();

        return services;
    }
}
