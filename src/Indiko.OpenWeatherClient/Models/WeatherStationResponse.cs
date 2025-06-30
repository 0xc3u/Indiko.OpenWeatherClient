using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;

/// <summary>
/// Represents the response from registering a weather station with the OpenWeather API.
/// </summary>
public sealed class WeatherStationResponse
{
    /// <summary>
    /// Gets or sets the unique identifier assigned by OpenWeatherMap to the weather station.
    /// </summary>
    [JsonPropertyName("ID")]
    public string Id { get; init; }

    /// <summary>
    /// Gets or sets the timestamp when the weather station was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; }

    /// <summary>
    /// Gets or sets the timestamp when the weather station was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Gets or sets the user ID associated with the weather station.
    /// </summary>
    [JsonPropertyName("user_id")]
    public string UserId { get; init; }

    /// <summary>
    /// Gets or sets the external identifier for the weather station.
    /// </summary>
    [JsonPropertyName("external_id")]
    public string ExternalId { get; init; }

    /// <summary>
    /// Gets or sets the name of the weather station.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    /// Gets or sets the latitude coordinate of the weather station.
    /// </summary>
    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }

    /// <summary>
    /// Gets or sets the longitude coordinate of the weather station.
    /// </summary>
    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }

    /// <summary>
    /// Gets or sets the altitude of the weather station in meters.
    /// </summary>
    [JsonPropertyName("altitude")]
    public double Altitude { get; init; }

    /// <summary>
    /// Gets or sets the source type identifier for the weather station.
    /// </summary>
    [JsonPropertyName("source_type")]
    public int SourceType { get; init; }
}