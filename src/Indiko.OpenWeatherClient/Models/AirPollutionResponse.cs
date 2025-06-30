using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;

/// <summary>
/// Represents the response from the OpenWeather Air Pollution API.
/// </summary>
public sealed class AirPollutionResponse
{
    /// <summary>
    /// Gets the geographical coordinates for the air pollution data.
    /// </summary>
    [JsonPropertyName("coord")]
    public double[] Coord { get; init; }

    /// <summary>
    /// Gets the array of air pollution data points.
    /// </summary>
    [JsonPropertyName("list")]
    public AirPollutionData[] List { get; init; }
}