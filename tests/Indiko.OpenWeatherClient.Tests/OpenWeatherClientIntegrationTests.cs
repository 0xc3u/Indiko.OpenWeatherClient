using Indiko.OpenWeatherClient.Models;
using FluentAssertions;

namespace Indiko.OpenWeatherClient.Tests;

public class OpenWeatherClientIntegrationTests(IntegrationTestFixture fixture) : IClassFixture<IntegrationTestFixture>
{
    private readonly IntegrationTestFixture _fixture = fixture;

    [Fact]
    public async Task GetCurrentWeatherAsync_ReturnsCorrectWeatherData()
    {
        // Arrange
        var request = new OpenWeatherRequest
        {
            ApiKey = _fixture.ApiKey,
            Latitude = 40.712776,
            Longitude = -74.005974,
            Language = Constants.Languages.English,
            Unit = Constants.Units.Metric,
            Excludes = [Constants.Excludes.Minutely, Constants.Excludes.Daily, Constants.Excludes.Hourly]
        };

        // Act
        var result = await _fixture.OpenWeatherClient.GetCurrentWeatherAsync(request);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetDailyWeatherAsync_ReturnsCorrectWeatherData()
    {
        // Arrange
        var request = new OpenWeatherRequest
        {
            ApiKey = _fixture.ApiKey,
            Latitude = 40.712776,
            Longitude = -74.005974,
            Language = Constants.Languages.English,
            Unit = Constants.Units.Metric,
            Excludes = [Constants.Excludes.Minutely, Constants.Excludes.Hourly, Constants.Excludes.Current]
        };

        // Act
        var result = await _fixture.OpenWeatherClient.GetDailyWeatherAsync(request);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetHourlyWeatherAsync_ReturnsCorrectWeatherData()
    {
        // Arrange
        var request = new OpenWeatherRequest
        {
            ApiKey = _fixture.ApiKey,
            Latitude = 40.712776,
            Longitude = -74.005974,
            Language = Constants.Languages.English,
            Unit = Constants.Units.Metric,
            Excludes = [Constants.Excludes.Minutely, Constants.Excludes.Daily, Constants.Excludes.Current]
        };

        // Act
        var result = await _fixture.OpenWeatherClient.GetHourlyWeatherAsync(request);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetWeatherAsync_ReturnsCorrectWeatherData()
    {
        // Arrange
        var request = new OpenWeatherRequest
        {
            ApiKey = _fixture.ApiKey,
            Latitude = 40.712776,
            Longitude = -74.005974,
            Language = Constants.Languages.English,
            Unit = Constants.Units.Metric,
            Excludes = [Constants.Excludes.Minutely]
        };

        // Act
        var result = await _fixture.OpenWeatherClient.GetWeatherAsync(request);

        // Assert
        result.Should().NotBeNull();
    }
}