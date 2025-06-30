using Indiko.OpenWeatherClient.Models;
using System.Threading.Tasks;

namespace Indiko.OpenWeatherClient.Interfaces;
public interface IOpenWeatherClient
{
    Task<Current> GetCurrentWeatherAsync(OpenWeatherRequest request, CancellationToken cancellationToken = default);

    Task<Day[]> GetDailyWeatherAsync(OpenWeatherRequest request, CancellationToken cancellationToken = default);

    Task<Hour[]> GetHourlyWeatherAsync(OpenWeatherRequest request, CancellationToken cancellationToken = default);

    Task<OpenWeatherResponse> GetWeatherAsync(OpenWeatherRequest request, CancellationToken cancellationToken = default);

    Uri GetMapTileUri(OpenWeatherMapTileRequest mapTileRequest);
    Task<byte[]> GetMapTileAsync(OpenWeatherMapTileRequest mapTileRequest, CancellationToken cancellationToken = default);

    Task<WeatherStationResponse> RegisterWeatherStationAsync(WeatherStationRequest request, CancellationToken cancellationToken = default);
}
