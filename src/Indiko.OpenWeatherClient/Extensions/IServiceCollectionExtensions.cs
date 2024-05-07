using Indiko.OpenWeatherClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Indiko.OpenWeatherClient.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="IServiceCollection"/> to facilitate the registration of OpenWeather API related services.
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds the OpenWeather client to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// This method configures the dependency injection container to provide an <see cref="IOpenWeatherClient"/>
    /// implementation whenever it is needed. It registers the <see cref="OpenWeatherClient"/> as a scoped service,
    /// which means a new instance is created once per client request.
    /// </remarks>
    public static IServiceCollection AddOpenWeatherClient(this IServiceCollection services)
    {
        services.AddScoped<IOpenWeatherClient, OpenWeatherClient>();

        return services;
    }
}