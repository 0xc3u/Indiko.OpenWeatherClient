namespace Indiko.OpenWeatherClient.Constants;

/// <summary>
/// Contains constant values that specify the unit systems used for reporting temperature and other measurements in the OpenWeather API responses.
/// </summary>
public static class Units
{
    /// <summary>
    /// Uses the Standard unit system. Temperature in Kelvin, speed in meter/sec, and other measurements in standard metric units.
    /// </summary>
    public const string Standard = "standard";

    /// <summary>
    /// Uses the Metric unit system. Temperature in Celsius, speed in meter/sec, and other measurements in metric units.
    /// </summary>
    public const string Metric = "metric";

    /// <summary>
    /// Uses the Imperial unit system. Temperature in Fahrenheit, speed in miles/hour, and other measurements in imperial units.
    /// </summary>
    public const string Imperial = "imperial";
}