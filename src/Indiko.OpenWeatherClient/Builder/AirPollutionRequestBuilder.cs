namespace Indiko.OpenWeatherClient.Builder;

/// <summary>
/// Provides a builder pattern to create and configure an OpenWeather Air Pollution API request.
/// </summary>
/// <param name="apiKey">The API key to authenticate requests.</param>
public class AirPollutionRequestBuilder(string apiKey)
{
    private readonly string _apiKey = apiKey;
    private double _latitude;
    private double _longitude;
    private DateTime? _startDate;
    private DateTime? _endDate;

    /// <summary>
    /// Specifies the geographical coordinates for the air pollution data request.
    /// </summary>
    /// <param name="latitude">The latitude coordinate.</param>
    /// <param name="longitude">The longitude coordinate.</param>
    public AirPollutionRequestBuilder WithLocation(double latitude, double longitude)
    {
        _latitude = latitude;
        _longitude = longitude;
        return this;
    }

    /// <summary>
    /// Specifies the date range for historical air pollution data requests.
    /// </summary>
    /// <param name="startDate">The start date for historical data.</param>
    /// <param name="endDate">The end date for historical data.</param>
    public AirPollutionRequestBuilder WithDateRange(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
        return this;
    }

    /// <summary>
    /// Builds the final URI for the current air pollution API request.
    /// </summary>
    /// <returns>The URI of the configured air pollution API request.</returns>
    public Uri BuildCurrent()
    {
        ValidateRequiredParameters();
        string requestUrl = $"http://api.openweathermap.org/data/2.5/air_pollution?lat={_latitude}&lon={_longitude}&appid={_apiKey}";
        return new Uri(requestUrl);
    }

    /// <summary>
    /// Builds the final URI for the air pollution forecast API request.
    /// </summary>
    /// <returns>The URI of the configured air pollution forecast API request.</returns>
    public Uri BuildForecast()
    {
        ValidateRequiredParameters();
        string requestUrl = $"http://api.openweathermap.org/data/2.5/air_pollution/forecast?lat={_latitude}&lon={_longitude}&appid={_apiKey}";
        return new Uri(requestUrl);
    }

    /// <summary>
    /// Builds the final URI for the historical air pollution API request.
    /// </summary>
    /// <returns>The URI of the configured historical air pollution API request.</returns>
    public Uri BuildHistorical()
    {
        ValidateRequiredParameters();
        if (!_startDate.HasValue || !_endDate.HasValue)
        {
            throw new ArgumentException("Start date and end date must be provided for historical air pollution data");
        }

        long startUnix = ((DateTimeOffset)_startDate.Value).ToUnixTimeSeconds();
        long endUnix = ((DateTimeOffset)_endDate.Value).ToUnixTimeSeconds();
        
        string requestUrl = $"http://api.openweathermap.org/data/2.5/air_pollution/history?lat={_latitude}&lon={_longitude}&start={startUnix}&end={endUnix}&appid={_apiKey}";
        return new Uri(requestUrl);
    }

    private void ValidateRequiredParameters()
    {
        if (string.IsNullOrEmpty(_apiKey))
        {
            throw new ArgumentException("API Key must be provided");
        }

        if (_latitude == 0 || _longitude == 0)
        {
            throw new ArgumentException("Latitude and Longitude must be provided");
        }
    }
}