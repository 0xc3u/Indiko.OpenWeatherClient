using Indiko.OpenWeatherClient.Builder;
using Indiko.OpenWeatherClient.Exceptions;
using Indiko.OpenWeatherClient.Interfaces;
using Indiko.OpenWeatherClient.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Indiko.OpenWeatherClient;

/// <summary>
/// A client for interacting with the OpenWeather API to fetch weather data and map tile data.
/// </summary>
public class OpenWeatherClient : IOpenWeatherClient, IDisposable
{
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private HttpClient _httpClient;

    public OpenWeatherClient()
    {
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve
        };
        _jsonSerializerOptions.Converters.Add(new Converter.UnixDateTimeConverter());

        _httpClient = new HttpClient();
    }

    /// <summary>
    /// Asynchronously retrieves the current weather data.
    /// </summary>
    /// <param name="request">Configuration for the API request.</param>
    /// <param name="cancellationToken">Cancellation token for the async operation.</param>
    /// <returns>A <see cref="Current"/> object containing the current weather data.</returns>
    public async Task<Current> GetCurrentWeatherAsync(OpenWeatherRequest request, CancellationToken cancellationToken = default)
    {
        var openWeatherResponse = await GetResponseInternal(request, cancellationToken);

        return openWeatherResponse.Current;
    }

    /// <summary>
    /// Asynchronously retrieves the daily weather forecast.
    /// </summary>
    /// <param name="request">Configuration for the API request.</param>
    /// <param name="cancellationToken">Cancellation token for the async operation.</param>
    /// <returns>An array of <see cref="Day"/> objects containing daily weather data.</returns>
    public async Task<Day[]> GetDailyWeatherAsync(OpenWeatherRequest request, CancellationToken cancellationToken = default)
    {
        var openWeatherResponse = await GetResponseInternal(request, cancellationToken);
        return openWeatherResponse.Daily;
    }

    /// <summary>
    /// Asynchronously retrieves the hourly weather forecast.
    /// </summary>
    /// <param name="request">Configuration for the API request.</param>
    /// <param name="cancellationToken">Cancellation token for the async operation.</param>
    /// <returns>An array of <see cref="Hour"/> objects containing hourly weather data.</returns>
    public async Task<Hour[]> GetHourlyWeatherAsync(OpenWeatherRequest request, CancellationToken cancellationToken = default)
    {
        var openWeatherResponse = await GetResponseInternal(request, cancellationToken);
        return openWeatherResponse.Hourly;
    }

    /// <summary>
    /// Asynchronously retrieves the complete weather data based on the specified request configuration.
    /// </summary>
    /// <param name="request">Configuration for the API request.</param>
    /// <param name="cancellationToken">Cancellation token for the async operation.</param>
    /// <returns>An <see cref="OpenWeatherResponse"/> object containing comprehensive weather data.</returns>
    public async Task<OpenWeatherResponse> GetWeatherAsync(OpenWeatherRequest request, CancellationToken cancellationToken = default)
    {
        var openWeatherResponse = await GetResponseInternal(request, cancellationToken);
        return openWeatherResponse;
    }

    private async Task<OpenWeatherResponse> GetResponseInternal(OpenWeatherRequest request, CancellationToken cancellationToken = default)
    {
        OpenWeatherRequestBuilder requestBuilder = new(request.ApiKey);

        if (!string.IsNullOrWhiteSpace(request.City) && !string.IsNullOrWhiteSpace(request.Country))
        {
            requestBuilder.WithCity(request.City, request.Country);
        }
        else if (request.Latitude != 0 && request.Longitude != 0)
        {
            requestBuilder.WithLocation(request.Latitude, request.Longitude);
        }

        if (!string.IsNullOrWhiteSpace(request.Language))
        {
            requestBuilder.WithLanguage(request.Language);
        }

        if (!string.IsNullOrWhiteSpace(request.Unit))
        {
            requestBuilder.WithUnit(request.Unit);
        }

        if (request.Date.HasValue)
        {
            requestBuilder.WithDate(request.Date.Value);
        }

        if (request.Excludes?.Length > 0)
        {
            requestBuilder.WithExcludes(request.Excludes);
        }

        var requestUrl = requestBuilder.Build();
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);

        var response = await _httpClient.SendAsync(requestMessage, cancellationToken)
                                .ConfigureAwait(false);

        switch (response.StatusCode)
        {
            case System.Net.HttpStatusCode.OK:
                {
                    var content = await response.Content.ReadAsStringAsync(cancellationToken)
                                        .ConfigureAwait(false);

                    return JsonSerializer.Deserialize<OpenWeatherResponse>(content, _jsonSerializerOptions);
                }
            default:
                {
                    var content = await response.Content.ReadAsStringAsync(cancellationToken)
                                          .ConfigureAwait(false);
                    throw new OpenWeatherException((int)response.StatusCode, content);
                }
        }
    }

    /// <summary>
    /// Constructs a URI for a specific map tile from the OpenWeatherMap tile service.
    /// </summary>
    /// <param name="mapTileRequest">Configuration for the map tile request.</param>
    /// <returns>A URI pointing to the map tile image.</returns>
    public Uri GetMapTileUri(OpenWeatherMapTileRequest mapTileRequest)
    {
        if (string.IsNullOrEmpty(mapTileRequest.ApiKey))
        {
            throw new ArgumentNullException(nameof(mapTileRequest.ApiKey));
        }

        if (string.IsNullOrEmpty(mapTileRequest.Layer))
        {
            throw new ArgumentNullException(nameof(mapTileRequest.Layer));
        }

        string url = $"https://tile.openweathermap.org/map/{mapTileRequest.Layer}/{mapTileRequest.ZoomLevel}/{mapTileRequest.X}/{mapTileRequest.Y}.png?appid={mapTileRequest.ApiKey}";
        return new Uri(url);
    }

    /// <summary>
    /// Asynchronously retrieves a map tile image from the OpenWeatherMap tile service.
    /// </summary>
    /// <param name="mapTileRequest">Configuration for the map tile request.</param>
    /// <param name="cancellationToken">Cancellation token for the async operation.</param>
    /// <returns>A byte array containing the map tile image.</returns>
    public async Task<byte[]> GetMapTileAsync(OpenWeatherMapTileRequest mapTileRequest, CancellationToken cancellationToken = default)
    {
        var url = GetMapTileUri(mapTileRequest);
        return await GetInternalMapTileAsync(url, cancellationToken);
    }

    public async Task<byte[]> GetInternalMapTileAsync(Uri url, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetByteArrayAsync(url, cancellationToken)
                                .ConfigureAwait(false);

        return response;
    }

    /// <summary>
    /// Asynchronously registers a weather station with the OpenWeather API.
    /// </summary>
    /// <param name="request">Configuration for the weather station registration request.</param>
    /// <param name="cancellationToken">Cancellation token for the async operation.</param>
    /// <returns>A <see cref="WeatherStationResponse"/> object containing the registered weather station data.</returns>
    public async Task<WeatherStationResponse> RegisterWeatherStationAsync(WeatherStationRequest request, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(request.ApiKey))
        {
            throw new ArgumentNullException(nameof(request.ApiKey));
        }

        if (string.IsNullOrEmpty(request.ExternalId))
        {
            throw new ArgumentNullException(nameof(request.ExternalId));
        }

        if (string.IsNullOrEmpty(request.Name))
        {
            throw new ArgumentNullException(nameof(request.Name));
        }

        var requestUrl = $"https://api.openweathermap.org/data/3.0/stations?appid={request.ApiKey}";
        
        var requestBody = new
        {
            external_id = request.ExternalId,
            name = request.Name,
            latitude = request.Latitude,
            longitude = request.Longitude,
            altitude = request.Altitude
        };

        var jsonContent = JsonSerializer.Serialize(requestBody, _jsonSerializerOptions);
        var httpContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl)
        {
            Content = httpContent
        };

        var response = await _httpClient.SendAsync(requestMessage, cancellationToken)
                                .ConfigureAwait(false);

        switch (response.StatusCode)
        {
            case System.Net.HttpStatusCode.Created:
                {
                    var content = await response.Content.ReadAsStringAsync(cancellationToken)
                                        .ConfigureAwait(false);

                    return JsonSerializer.Deserialize<WeatherStationResponse>(content, _jsonSerializerOptions);
                }
            default:
                {
                    var content = await response.Content.ReadAsStringAsync(cancellationToken)
                                          .ConfigureAwait(false);
                    throw new OpenWeatherException((int)response.StatusCode, content);
                }
        }
    }

    public void Dispose()
    {
        if (_httpClient != null)
        {
            _httpClient.CancelPendingRequests();
            _httpClient.Dispose();
            _httpClient = null;
        }
    }

    /// <summary>
    /// Asynchronously retrieves the current air pollution data.
    /// </summary>
    /// <param name="request">Configuration for the air pollution API request.</param>
    /// <param name="cancellationToken">Cancellation token for the async operation.</param>
    /// <returns>An <see cref="AirPollutionResponse"/> object containing current air pollution data.</returns>
    public async Task<AirPollutionResponse> GetCurrentAirPollutionAsync(AirPollutionRequest request, CancellationToken cancellationToken = default)
    {
        return await GetAirPollutionResponseInternal(request, AirPollutionType.Current, cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the air pollution forecast data.
    /// </summary>
    /// <param name="request">Configuration for the air pollution API request.</param>
    /// <param name="cancellationToken">Cancellation token for the async operation.</param>
    /// <returns>An <see cref="AirPollutionResponse"/> object containing air pollution forecast data.</returns>
    public async Task<AirPollutionResponse> GetAirPollutionForecastAsync(AirPollutionRequest request, CancellationToken cancellationToken = default)
    {
        return await GetAirPollutionResponseInternal(request, AirPollutionType.Forecast, cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the historical air pollution data.
    /// </summary>
    /// <param name="request">Configuration for the air pollution API request.</param>
    /// <param name="cancellationToken">Cancellation token for the async operation.</param>
    /// <returns>An <see cref="AirPollutionResponse"/> object containing historical air pollution data.</returns>
    public async Task<AirPollutionResponse> GetHistoricalAirPollutionAsync(AirPollutionRequest request, CancellationToken cancellationToken = default)
    {
        return await GetAirPollutionResponseInternal(request, AirPollutionType.Historical, cancellationToken);
    }

    private async Task<AirPollutionResponse> GetAirPollutionResponseInternal(AirPollutionRequest request, AirPollutionType type, CancellationToken cancellationToken = default)
    {
        AirPollutionRequestBuilder requestBuilder = new(request.ApiKey);
        requestBuilder.WithLocation(request.Latitude, request.Longitude);

        if (type == AirPollutionType.Historical && request.StartDate.HasValue && request.EndDate.HasValue)
        {
            requestBuilder.WithDateRange(request.StartDate.Value, request.EndDate.Value);
        }

        Uri requestUrl = type switch
        {
            AirPollutionType.Current => requestBuilder.BuildCurrent(),
            AirPollutionType.Forecast => requestBuilder.BuildForecast(),
            AirPollutionType.Historical => requestBuilder.BuildHistorical(),
            _ => throw new ArgumentException("Invalid air pollution type")
        };

        var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);

        var response = await _httpClient.SendAsync(requestMessage, cancellationToken)
                                .ConfigureAwait(false);

        switch (response.StatusCode)
        {
            case System.Net.HttpStatusCode.OK:
                {
                    var content = await response.Content.ReadAsStringAsync(cancellationToken)
                                        .ConfigureAwait(false);

                    return JsonSerializer.Deserialize<AirPollutionResponse>(content, _jsonSerializerOptions);
                }
            default:
                {
                    var content = await response.Content.ReadAsStringAsync(cancellationToken)
                                          .ConfigureAwait(false);
                    throw new OpenWeatherException((int)response.StatusCode, content);
                }
        }
    }

    private enum AirPollutionType
    {
        Current,
        Forecast,
        Historical
    }
}