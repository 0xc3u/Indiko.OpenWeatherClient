using Indiko.OpenWeatherClient.Models;
using FluentAssertions;

namespace Indiko.OpenWeatherClient.Tests;

public class WeatherStationTests : IDisposable
{
    private readonly OpenWeatherClient _client;

    public WeatherStationTests()
    {
        _client = new OpenWeatherClient();
    }

    [Fact]
    public async Task RegisterWeatherStationAsync_WithNullApiKey_ThrowsArgumentNullException()
    {
        // Arrange
        var request = new WeatherStationRequest
        {
            ApiKey = null,
            ExternalId = "TEST001",
            Name = "Test Station",
            Latitude = 37.76,
            Longitude = -122.43,
            Altitude = 150
        };

        // Act & Assert
        await _client.Invoking(c => c.RegisterWeatherStationAsync(request))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("ApiKey");
    }

    [Fact]
    public async Task RegisterWeatherStationAsync_WithNullExternalId_ThrowsArgumentNullException()
    {
        // Arrange
        var request = new WeatherStationRequest
        {
            ApiKey = "test-api-key",
            ExternalId = null,
            Name = "Test Station",
            Latitude = 37.76,
            Longitude = -122.43,
            Altitude = 150
        };

        // Act & Assert
        await _client.Invoking(c => c.RegisterWeatherStationAsync(request))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("ExternalId");
    }

    [Fact]
    public async Task RegisterWeatherStationAsync_WithNullName_ThrowsArgumentNullException()
    {
        // Arrange
        var request = new WeatherStationRequest
        {
            ApiKey = "test-api-key",
            ExternalId = "TEST001",
            Name = null,
            Latitude = 37.76,
            Longitude = -122.43,
            Altitude = 150
        };

        // Act & Assert
        await _client.Invoking(c => c.RegisterWeatherStationAsync(request))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName("Name");
    }

    [Fact]
    public void WeatherStationRequest_CanBeCreatedWithValidData()
    {
        // Act
        var request = new WeatherStationRequest
        {
            ApiKey = "test-api-key",
            ExternalId = "SF_TEST001",
            Name = "San Francisco Test Station",
            Latitude = 37.76,
            Longitude = -122.43,
            Altitude = 150
        };

        // Assert
        request.Should().NotBeNull();
        request.ApiKey.Should().Be("test-api-key");
        request.ExternalId.Should().Be("SF_TEST001");
        request.Name.Should().Be("San Francisco Test Station");
        request.Latitude.Should().Be(37.76);
        request.Longitude.Should().Be(-122.43);
        request.Altitude.Should().Be(150);
    }

    [Fact]
    public void WeatherStationResponse_CanBeDeserialized()
    {
        // Arrange
        var jsonResponse = """
        {
          "ID": "583436dd9643a9000196b8d6",
          "updated_at": "2016-11-22T12:15:25.96727176Z",
          "created_at": "2016-11-22T12:15:25.967271732Z",
          "user_id": "557066d0ff7a7e3897531d94",
          "external_id": "SF_TEST001",
          "name": "San Francisco Test Station",
          "latitude": 37.76,
          "longitude": -122.43,
          "altitude": 150,
          "source_type": 5
        }
        """;

        // Act
        var response = System.Text.Json.JsonSerializer.Deserialize<WeatherStationResponse>(jsonResponse);

        // Assert
        response.Should().NotBeNull();
        response.Id.Should().Be("583436dd9643a9000196b8d6");
        response.ExternalId.Should().Be("SF_TEST001");
        response.Name.Should().Be("San Francisco Test Station");
        response.Latitude.Should().Be(37.76);
        response.Longitude.Should().Be(-122.43);
        response.Altitude.Should().Be(150);
        response.SourceType.Should().Be(5);
    }

    public void Dispose()
    {
        _client?.Dispose();
    }
}