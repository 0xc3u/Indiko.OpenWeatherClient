using Indiko.OpenWeatherClient.Converter;
using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;

/// <summary>
/// Represents a weather alert issued by a weather data provider, detailing significant weather events.
/// </summary>
public sealed class Alert
{
    /// <summary>
    /// Gets the name of the organization that issued the alert.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("sender_name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string SenderName { get; init; }

    /// <summary>
    /// Gets the name of the weather event that triggered the alert.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("event")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Event { get; init; }

    /// <summary>
    /// Gets the start time of the weather event, represented as a nullable DateTime.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("start")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? Start { get; init; }

    /// <summary>
    /// Gets the end time of the weather event, represented as a nullable DateTime.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("end")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? End { get; init; }

    /// <summary>
    /// Gets the detailed description of the weather event and its potential impact.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Description { get; init; }

    /// <summary>
    /// Gets the tags associated with the alert, which categorize the nature of the event.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("tags")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[] Tags { get; init; }
}
