using ExtendedHttpClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExtendedHttpClient.Extensions;

public static class Extensions
{
    public static IServiceCollection AddServiceWithExtendedHttpClient<TClass, TImplementation>(this IServiceCollection services, string uri)
        where TClass : class, IUseExtendedHttpClient<TClass>
        where TImplementation : class, TClass
    {
        services.AddSingleton(provider => new ExtendedHttpClientOptions<TClass>(uri));
        services.AddTransient<ExtendedHttpClient<TClass>>();
        services.AddTransient<TClass, TImplementation>();

        return services;
    }

    public static IServiceCollection AddServiceWithExtendedHttpClient<TClass>(this IServiceCollection services, string uri)
        where TClass : class, IUseExtendedHttpClient<TClass>
    {
        services.AddSingleton(provider => new ExtendedHttpClientOptions<TClass>(uri));
        services.AddTransient<ExtendedHttpClient<TClass>>();
        services.AddTransient<TClass>();

        return services;
    }
    
    public static IServiceCollection AddServiceWithExtendedHttpClient<TClass, TImplementation>(this IServiceCollection services, Action<HttpClient> httpOptions)
        where TClass : class, IUseExtendedHttpClient<TClass>
        where TImplementation : class, TClass
    {
        services.AddSingleton(provider => new ExtendedHttpClientOptions<TClass>(httpOptions));
        services.AddTransient<ExtendedHttpClient<TClass>>();
        services.AddTransient<TClass, TImplementation>();

        return services;
    }

    public static IServiceCollection AddServiceWithExtendedHttpClient<TClass>(this IServiceCollection services, Action<HttpClient> httpOptions)
        where TClass : class, IUseExtendedHttpClient<TClass>
    {
        services.AddSingleton(provider => new ExtendedHttpClientOptions<TClass>(httpOptions));
        services.AddTransient<ExtendedHttpClient<TClass>>();
        services.AddTransient<TClass>();

        return services;
    }
}
