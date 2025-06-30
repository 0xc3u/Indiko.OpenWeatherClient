using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;

/// <summary>
/// Represents the Air Quality Index with the qualitative assessment.
/// </summary>
public sealed class AirQualityIndex
{
    /// <summary>
    /// Gets the Air Quality Index level.
    /// 1 = Good, 2 = Fair, 3 = Moderate, 4 = Poor, 5 = Very Poor
    /// </summary>
    [JsonPropertyName("aqi")]
    public int Aqi { get; init; }
}