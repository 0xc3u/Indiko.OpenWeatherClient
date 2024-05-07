using Indiko.OpenWeatherClient.Converter;
using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;
public class Weather
{
    /// <summary>
    /// Gets the date and time of the weather data point. 
    /// This property is represented as a Unix timestamp in the JSON data.
    /// </summary>
    [JsonPropertyName("dt")]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime? DateTime { get; init; }

    /// <summary>
    /// Gets the atmospheric pressure in unit specified.
    /// </summary>
    [JsonPropertyName("pressure")]
    public int Pressure { get; init; }

    /// <summary>
    /// Gets the humidity percentage.
    /// </summary>
    [JsonPropertyName("humidity")]
    public int Humidity { get; init; }

    /// <summary>
    /// Gets the dew point temperature in unit specified.
    /// </summary>
    [JsonPropertyName("dew_point")]
    public float DewPoint { get; init; }

    /// <summary>
    /// Gets the current ultraviolet index.
    /// </summary>
    [JsonPropertyName("uvi")]
    public float UvIndex { get; init; }

    /// <summary>
    /// Gets the cloud coverage percentage.
    /// </summary>
    [JsonPropertyName("clouds")]
    public int Clouds { get; init; }

    /// <summary>
    /// Gets the visibility in unit specified.
    /// </summary>
    [JsonPropertyName("visibility")]
    public int Visibility { get; init; }

    /// <summary>
    /// Gets the wind speed in unit specified.
    /// </summary>
    [JsonPropertyName("wind_speed")]
    public float WindSpeed { get; init; }

    /// <summary>
    /// Gets the wind direction in degrees (meteorological).
    /// </summary>
    [JsonPropertyName("wind_deg")]
    public int WindDeg { get; init; }

    /// <summary>
    /// Gets the wind gust speed in unit specified.
    /// </summary>
    [JsonPropertyName("wind_gust")]
    public float WindGust { get; init; }

    /// <summary>
    /// Gets an array of weather conditions information. 
    /// This property will be ignored when writing to JSON if the value is null.
    /// </summary>
    [JsonPropertyName("weather")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public WeatherInformation[] WeatherInformation { get; init; }
}