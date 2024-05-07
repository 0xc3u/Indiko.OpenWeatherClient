using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;
public class Temperature
{
    /// <summary>
    /// Gets the average daytime temperature in unit specified.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("day")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Day { get; init; }

    /// <summary>
    /// Gets the minimum recorded temperature in unit specified for the day.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("min")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Min { get; init; }

    /// <summary>
    /// Gets the maximum recorded temperature in unit specified for the day.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("max")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Max { get; init; }

    /// <summary>
    /// Gets the average nighttime temperature in unit specified.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("night")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Night { get; init; }

    /// <summary>
    /// Gets the average evening temperature in unit specified.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("eve")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Eve { get; init; }

    /// <summary>
    /// Gets the average morning temperature in unit specified.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("morn")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Morn { get; init; }
}