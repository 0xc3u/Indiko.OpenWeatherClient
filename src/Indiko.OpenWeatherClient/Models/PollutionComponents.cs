using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;

/// <summary>
/// Represents the concentration of various air pollutants in μg/m³.
/// </summary>
public sealed class PollutionComponents
{
    /// <summary>
    /// Gets the concentration of Carbon monoxide (CO) in μg/m³.
    /// </summary>
    [JsonPropertyName("co")]
    public double Co { get; init; }

    /// <summary>
    /// Gets the concentration of Nitrogen monoxide (NO) in μg/m³.
    /// </summary>
    [JsonPropertyName("no")]
    public double No { get; init; }

    /// <summary>
    /// Gets the concentration of Nitrogen dioxide (NO2) in μg/m³.
    /// </summary>
    [JsonPropertyName("no2")]
    public double No2 { get; init; }

    /// <summary>
    /// Gets the concentration of Ozone (O3) in μg/m³.
    /// </summary>
    [JsonPropertyName("o3")]
    public double O3 { get; init; }

    /// <summary>
    /// Gets the concentration of Sulphur dioxide (SO2) in μg/m³.
    /// </summary>
    [JsonPropertyName("so2")]
    public double So2 { get; init; }

    /// <summary>
    /// Gets the concentration of Fine particles matter (PM2.5) in μg/m³.
    /// </summary>
    [JsonPropertyName("pm2_5")]
    public double Pm2_5 { get; init; }

    /// <summary>
    /// Gets the concentration of Coarse particulate matter (PM10) in μg/m³.
    /// </summary>
    [JsonPropertyName("pm10")]
    public double Pm10 { get; init; }

    /// <summary>
    /// Gets the concentration of Ammonia (NH3) in μg/m³.
    /// </summary>
    [JsonPropertyName("nh3")]
    public double Nh3 { get; init; }
}