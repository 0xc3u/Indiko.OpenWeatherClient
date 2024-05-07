using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;

/// <summary>
/// Represents detailed information about weather conditions.
/// </summary>
public class WeatherInformation
{
    /// <summary>
    /// Gets the weather condition ID, a unique identifier for a specific weather condition type.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int Id { get; init; }

    /// <summary>
    /// Gets the main group to which the weather condition belongs, such as "Rain", "Snow", etc.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("main")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Main { get; init; }

    /// <summary>
    /// Gets a more detailed description of the weather condition.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Description { get; init; }

    /// <summary>
    /// Gets the icon code representing the weather condition visually.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("icon")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Icon { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public string Icon100Url => !string.IsNullOrEmpty(Icon) ? $"https://openweathermap.org/img/wn/{Icon}@2x.png" : string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public string Icon200Url => !string.IsNullOrEmpty(Icon) ? $"https://openweathermap.org/img/wn/{Icon}@4x.png" : string.Empty;
}
