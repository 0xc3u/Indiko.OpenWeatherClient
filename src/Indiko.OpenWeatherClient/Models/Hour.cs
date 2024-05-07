using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;
public sealed class Hour : Weather
{
    /// <summary>
    /// Gets the temperature at the specific hour in unit specified.
    /// </summary>
    [JsonPropertyName("temp")]
    public float Temperature { get; init; }

    /// <summary>
    /// Gets the perceived temperature at the specific hour in unit specified, 
    /// considering factors like wind and humidity.
    /// </summary>
    [JsonPropertyName("feels_like")]
    public float FeelsLike { get; init; }

    /// <summary>
    /// Gets the rainfall data for the specific hour unit specified. 
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("rain")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OneHour Rain { get; init; }

    /// <summary>
    /// Gets the snowfall data for the specific hour unit specified. 
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("snow")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OneHour Snow { get; init; }

    /// <summary>
    /// Gets the Probability Of Precipitation for the specific hour unit specified.
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("pop")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? ProbabilityOfPrecipitation { get; init; }
}
