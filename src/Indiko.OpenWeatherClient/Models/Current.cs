using Indiko.OpenWeatherClient.Converter;
using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;

public sealed class Current : Weather
{
    /// <summary>
    /// Gets the sunrise time for the current day. 
    /// This property is represented as a Unix timestamp in the JSON data and will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("sunrise")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? Sunrise { get; init; }

    /// <summary>
    /// Gets the sunset time for the current day. 
    /// This property is represented as a Unix timestamp in the JSON data and will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("sunset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? Sunset { get; init; }

    /// <summary>
    /// Gets the current temperature in unit specified.
    /// </summary>
    [JsonPropertyName("temp")]
    public float Temperature { get; init; }

    /// <summary>
    /// Gets the perceived temperature in unit specified, considering the impact of wind and humidity.
    /// </summary>
    [JsonPropertyName("feels_like")]
    public float FeelsLike { get; init; }

    /// <summary>
    /// Gets the rainfall data for the last hour unit specified. 
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("rain")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OneHour Rain { get; init; }

    /// <summary>
    /// Gets the snowfall data for the last hour unit specified. 
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("snow")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OneHour Snow { get; init; }
}
