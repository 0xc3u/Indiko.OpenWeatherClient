using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;
public sealed class OpenWeatherResponse
{
    /// <summary>
    /// Gets or sets the latitude of the location for which weather data is provided.
    /// </summary>
    [JsonPropertyName("lat")]
    public double Latitude { get; init; }

    /// <summary>
    /// Gets or sets the longitude of the location for which weather data is provided.
    /// </summary>
    [JsonPropertyName("lon")]
    public double Longitude { get; init; }

    /// <summary>
    /// Gets or sets the IANA timezone name for the location.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string Timezone { get; init; }

    /// <summary>
    /// Gets or sets the offset in seconds from UTC for the location's timezone.
    /// </summary>
    [JsonPropertyName("timezone_offset")]
    public int TimezoneOffset { get; init; }

    /// <summary>
    /// Gets or sets the current weather conditions data.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("current")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Current Current { get; init; }

    /// <summary>
    /// Gets or sets the array of hourly weather forecasts.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("hourly")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Hour[] Hourly { get; init; }

    /// <summary>
    /// Gets or sets the array of daily weather forecasts.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("daily")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Day[] Daily { get; init; }

    [JsonPropertyName("alerts")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Alert[] Alerts { get; init; }
}
