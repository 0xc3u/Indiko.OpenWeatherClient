using Indiko.OpenWeatherClient.Constants;

namespace Indiko.OpenWeatherClient.Builder;

/// <summary>
/// Provides a builder pattern to create and configure an OpenWeather API request.
/// </summary>
/// <param name="apiKey">The API key to authenticate requests.</param>
public class OpenWeatherRequestBuilder(string apiKey)
{
    private readonly string _apiKey = apiKey;
    private string _language = Languages.English;
    private string _unit = Units.Metric;
    private string[] _excludes = [];
    private double _latitude;
    private double _longitude;
    private string _city;
    private string _country;
    private DateTime? _date;
    private bool _useGeoCoding;

    /// <summary>
    /// Specifies the date for the request, typically used for historical data.
    /// </summary>
    /// <param name="date">The date of interest.</param>
    public OpenWeatherRequestBuilder WithDate(DateTime date)
    {
        _date = date;
        return this;
    }

    /// <summary>
    /// Specifies the language for the response data.
    /// </summary>
    /// <param name="language">The language code (ISO 639-1).</param>
    public OpenWeatherRequestBuilder WithLanguage(string language)
    {
        _language = language;
        return this;
    }

    /// <summary>
    /// Specifies the unit of measurement for temperature and other values.
    /// </summary>
    /// <param name="unit">The unit system to use ('metric' or 'imperial').</param>
    public OpenWeatherRequestBuilder WithUnit(string unit)
    {
        _unit = unit;
        return this;
    }
    /// <summary>
    /// Specifies the geographical coordinates for the weather data request.
    /// </summary>
    /// <param name="latitude">The latitude coordinate.</param>
    /// <param name="longitude">The longitude coordinate.</param>
    public OpenWeatherRequestBuilder WithLocation(double latitude, double longitude)
    {
        _latitude = latitude;
        _longitude = longitude;
        _useGeoCoding = false;
        return this;
    }

    /// <summary>
    /// Specifies the city and country for the weather data request.
    /// </summary>
    /// <param name="city">The name of the city.</param>
    /// <param name="country">The country code (ISO 3166).</param>
    public OpenWeatherRequestBuilder WithCity(string city, string country)
    {
        _city = city;
        _country = country;
        _useGeoCoding = true;
        return this;
    }

    /// <summary>
    /// Specifies the features to exclude from the response data.
    /// </summary>
    /// <param name="excludes">An array of features to exclude.</param>
    public OpenWeatherRequestBuilder WithExcludes(string[] excludes)
    {
        _excludes = excludes;
        return this;
    }

    /// <summary>
    /// Builds the final URI for the OpenWeather API request based on the configured options.
    /// Throws an exception if required parameters are not provided or incorrectly configured.
    /// </summary>
    /// <returns>The URI of the configured OpenWeather API request.</returns>
    public Uri Build()
    {
        if (string.IsNullOrEmpty(_apiKey))
        {
            throw new ArgumentException("API Key must be provided");
        }

        string requestUrl = $"https://api.openweathermap.org/data/3.0/onecall?appid={_apiKey}&lang={_language}&units={_unit}";
        if (_useGeoCoding)
        {
            if (_latitude != 0 && _longitude != 0)
            {
                throw new ArgumentException("Latitude and Longitude must be 0 when using city and country");
            }
            if (string.IsNullOrEmpty(_city) || string.IsNullOrEmpty(_country))
            {
                throw new ArgumentException("City and Country must be provided when using city and country");
            }

            requestUrl = $"{requestUrl}&q={_city},{_country}";
        }
        else
        {
            if (_latitude == 0 || _longitude == 0)
            {
                throw new ArgumentException("Latitude and Longitude must be provided when not using city and country");
            }

            requestUrl = $"{requestUrl}&lat={_latitude}&lon={_longitude}";
        }

        if (_date.HasValue)
        {
            requestUrl = $"{requestUrl}&date={_date.Value.ToShortDateString()}";
        }

        if (_excludes != null)
        {
            requestUrl = $"{requestUrl}&exclude={string.Join(",", _excludes)}";
        }

        return new Uri(requestUrl);
    }
}
