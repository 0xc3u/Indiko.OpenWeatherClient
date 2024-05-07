namespace Indiko.OpenWeatherClient.Constants;

/// <summary>
/// Contains constant values that specify which data components to exclude from the responses in OpenWeather API requests.
/// </summary>
public static class Excludes
{
    /// <summary>
    /// Excludes the current weather data from the API response.
    /// </summary>
    public const string Current = "current";

    /// <summary>
    /// Excludes the minutely weather data (e.g., precipitation) from the API response.
    /// </summary>
    public const string Minutely = "minutely";

    /// <summary>
    /// Excludes the hourly forecast data from the API response.
    /// </summary>
    public const string Hourly = "hourly";

    /// <summary>
    /// Excludes the daily forecast data from the API response.
    /// </summary>
    public const string Daily = "daily";

    /// <summary>
    /// Excludes weather alerts from the API response.
    /// </summary>
    public const string Alerts = "alerts";

    /// <summary>
    /// Excludes all optional data components (current, minutely, hourly, daily, and alerts) from the API response.
    /// </summary>
    public const string All = "current,minutely,hourly,daily,alerts";
}