using Indiko.OpenWeatherClient.Converter;
using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;
public sealed class Day : Weather
{
    /// <summary>
    /// Gets the sunrise time for the day. 
    /// This property is represented as a Unix timestamp in the JSON data and will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("sunrise")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? Sunrise { get; init; }

    /// <summary>
    /// Gets the sunset time for the day. 
    /// This property is represented as a Unix timestamp in the JSON data and will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("sunset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? Sunset { get; init; }

    /// <summary>
    /// Gets the moonrise time for the day. 
    /// This property is represented as a Unix timestamp in the JSON data and will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("moonrise")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? Moonrise { get; init; }

    /// <summary>
    /// Gets the moonset time for the day. 
    /// This property is represented as a Unix timestamp in the JSON data and will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("moonset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? Moonset { get; init; }

    /// <summary>
    /// Gets the moon phase for the day. 
    /// The value ranges from 0.0 (new moon) to 1.0 (full moon).
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("moon_phase")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? MoonPhase { get; init; }

    /// <summary>
    /// Gets a summary of the day's weather conditions.
    /// </summary>
    [JsonPropertyName("summary")]
    public string Summary { get; init; }

    /// <summary>
    /// Gets the detailed temperature information for the day, 
    /// including minimum, maximum, and average temperatures in unit specified.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("temp")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Temperature Temperature { get; init; }

    /// <summary>
    /// Gets the perceived temperature details for the day,
    /// considering factors such as wind and humidity in unit specified.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("feels_like")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Temperature FeelsLike { get; init; }

    /// <summary>
    /// Gets the recorded rainfall in unit specified for the day.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("rain")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Rain { get; init; }

    /// <summary>
    /// Gets the recorded snowfall in unit specified for the day.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("snow")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Snow { get; init; }
}
