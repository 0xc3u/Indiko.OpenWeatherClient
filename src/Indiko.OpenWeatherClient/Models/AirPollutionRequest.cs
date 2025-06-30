namespace Indiko.OpenWeatherClient.Models;

/// <summary>
/// Represents a request to the OpenWeather Air Pollution API.
/// </summary>
public record AirPollutionRequest
{
    /// <summary>
    /// Gets the API key used for authentication with the OpenWeather API.
    /// </summary>
    public string ApiKey { get; init; }

    /// <summary>
    /// Gets the latitude coordinate for the location for which air pollution data is requested.
    /// </summary>
    public double Latitude { get; init; }

    /// <summary>
    /// Gets the longitude coordinate for the location for which air pollution data is requested.
    /// </summary>
    public double Longitude { get; init; }

    /// <summary>
    /// Gets the start date for historical air pollution data requests.
    /// Optional; only needed for historical data requests.
    /// </summary>
    public DateTime? StartDate { get; init; }

    /// <summary>
    /// Gets the end date for historical air pollution data requests.
    /// Optional; only needed for historical data requests.
    /// </summary>
    public DateTime? EndDate { get; init; }
}