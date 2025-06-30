using Indiko.OpenWeatherClient.Converter;
using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;

/// <summary>
/// Represents a single air pollution data point with timestamp, air quality index, and pollutant concentrations.
/// </summary>
public sealed class AirPollutionData
{
    /// <summary>
    /// Gets the date and time of the air pollution data point.
    /// This property is represented as a Unix timestamp in the JSON data.
    /// </summary>
    [JsonPropertyName("dt")]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? DateTime { get; init; }

    /// <summary>
    /// Gets the air quality index information.
    /// </summary>
    [JsonPropertyName("main")]
    public AirQualityIndex Main { get; init; }

    /// <summary>
    /// Gets the concentration of various pollutants.
    /// </summary>
    [JsonPropertyName("components")]
    public PollutionComponents Components { get; init; }
}