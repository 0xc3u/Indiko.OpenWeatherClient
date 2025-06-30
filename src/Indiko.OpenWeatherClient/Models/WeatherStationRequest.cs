namespace Indiko.OpenWeatherClient.Models;

/// <summary>
/// Represents a request to register a weather station with the OpenWeather API.
/// </summary>
public record WeatherStationRequest
{
    /// <summary>
    /// Gets the API key used for authentication with the OpenWeather API.
    /// </summary>
    public string ApiKey { get; init; }

    /// <summary>
    /// Gets the external identifier for the weather station.
    /// </summary>
    public string ExternalId { get; init; }

    /// <summary>
    /// Gets the name of the weather station.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Gets the latitude coordinate for the weather station location.
    /// </summary>
    public double Latitude { get; init; }

    /// <summary>
    /// Gets the longitude coordinate for the weather station location.
    /// </summary>
    public double Longitude { get; init; }

    /// <summary>
    /// Gets the altitude of the weather station in meters.
    /// </summary>
    public double Altitude { get; init; }
}