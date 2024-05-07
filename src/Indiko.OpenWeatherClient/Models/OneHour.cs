using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Models;

/// <summary>
/// Represents precipitation data for a one-hour period.
/// </summary>
public class OneHour
{
    /// <summary>
    /// Gets the amount of precipitation in unit specified measured during the one-hour period.
    /// This property is serialized into JSON using the key "1h".
    /// </summary>
    [JsonPropertyName("1h")]
    public float Amount { get; init; }
}
