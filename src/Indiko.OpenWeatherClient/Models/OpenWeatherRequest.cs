namespace Indiko.OpenWeatherClient.Models;

/// <summary>
/// Represents a request to the OpenWeather API, containing all necessary parameters to retrieve weather data.
/// </summary>
public record OpenWeatherRequest
{
    /// <summary>
    /// Gets the API key used for authentication with the OpenWeather API.
    /// </summary>
    public string ApiKey { get; init; }

    /// <summary>
    /// Gets the name of the city for which weather data is requested.
    /// </summary>
    public string City { get; init; }

    /// <summary>
    /// Gets the country code (ISO 3166) of the city for which weather data is requested.
    /// </summary>
    public string Country { get; init; }

    /// <summary>
    /// Gets the latitude coordinate for the location for which weather data is requested.
    /// </summary>
    public double Latitude { get; init; }

    /// <summary>
    /// Gets the longitude coordinate for the location for which weather data is requested.
    /// </summary>
    public double Longitude { get; init; }

    /// <summary>
    /// Gets the language code (ISO 639-1) for the response data from the OpenWeather API.
    /// </summary>
    public string Language { get; init; }

    /// <summary>
    /// Gets the unit of measurement for temperature and wind speed (e.g., 'metric', 'imperial').
    /// </summary>
    public string Unit { get; init; }

    /// <summary>
    /// Gets the array of weather data features to exclude from the API response (e.g., 'current', 'minutely', 'daily').
    /// </summary>
    public string[] Excludes { get; init; }

    /// <summary>
    /// Gets the specific date for which historical weather data is requested.
    /// Optional; only needed for historical data requests.
    /// </summary>
    public DateTime? Date { get; init; }
}
