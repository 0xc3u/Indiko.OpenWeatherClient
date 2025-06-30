using Indiko.OpenWeatherClient.Builder;
using Indiko.OpenWeatherClient.Models;
using FluentAssertions;

namespace Indiko.OpenWeatherClient.Tests;

public class AirPollutionTests
{
    [Fact]
    public void AirPollutionRequestBuilder_BuildCurrent_ReturnsCorrectUrl()
    {
        // Arrange
        var apiKey = "test-api-key";
        var latitude = 50.0;
        var longitude = 50.0;
        var builder = new AirPollutionRequestBuilder(apiKey);

        // Act
        var uri = builder.WithLocation(latitude, longitude).BuildCurrent();

        // Assert
        uri.Should().NotBeNull();
        uri.ToString().Should().Be($"http://api.openweathermap.org/data/2.5/air_pollution?lat={latitude}&lon={longitude}&appid={apiKey}");
    }

    [Fact]
    public void AirPollutionRequestBuilder_BuildForecast_ReturnsCorrectUrl()
    {
        // Arrange
        var apiKey = "test-api-key";
        var latitude = 40.712776;
        var longitude = -74.005974;
        var builder = new AirPollutionRequestBuilder(apiKey);

        // Act
        var uri = builder.WithLocation(latitude, longitude).BuildForecast();

        // Assert
        uri.Should().NotBeNull();
        uri.ToString().Should().Be($"http://api.openweathermap.org/data/2.5/air_pollution/forecast?lat={latitude}&lon={longitude}&appid={apiKey}");
    }

    [Fact]
    public void AirPollutionRequestBuilder_BuildHistorical_ReturnsCorrectUrl()
    {
        // Arrange
        var apiKey = "test-api-key";
        var latitude = 50.0;
        var longitude = 50.0;
        var startDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var endDate = new DateTime(2023, 1, 2, 0, 0, 0, DateTimeKind.Utc);
        var builder = new AirPollutionRequestBuilder(apiKey);

        // Act
        var uri = builder.WithLocation(latitude, longitude)
                         .WithDateRange(startDate, endDate)
                         .BuildHistorical();

        // Assert
        uri.Should().NotBeNull();
        var expectedStartUnix = ((DateTimeOffset)startDate).ToUnixTimeSeconds();
        var expectedEndUnix = ((DateTimeOffset)endDate).ToUnixTimeSeconds();
        uri.ToString().Should().Be($"http://api.openweathermap.org/data/2.5/air_pollution/history?lat={latitude}&lon={longitude}&start={expectedStartUnix}&end={expectedEndUnix}&appid={apiKey}");
    }

    [Fact]
    public void AirPollutionRequestBuilder_BuildCurrent_ThrowsExceptionWhenApiKeyIsEmpty()
    {
        // Arrange
        var builder = new AirPollutionRequestBuilder("");

        // Act & Assert
        var action = () => builder.WithLocation(50.0, 50.0).BuildCurrent();
        action.Should().Throw<ArgumentException>().WithMessage("API Key must be provided");
    }

    [Fact]
    public void AirPollutionRequestBuilder_BuildCurrent_ThrowsExceptionWhenLocationNotSet()
    {
        // Arrange
        var builder = new AirPollutionRequestBuilder("test-api-key");

        // Act & Assert
        var action = () => builder.BuildCurrent();
        action.Should().Throw<ArgumentException>().WithMessage("Latitude and Longitude must be provided");
    }

    [Fact]
    public void AirPollutionRequestBuilder_BuildHistorical_ThrowsExceptionWhenDateRangeNotSet()
    {
        // Arrange
        var builder = new AirPollutionRequestBuilder("test-api-key");

        // Act & Assert
        var action = () => builder.WithLocation(50.0, 50.0).BuildHistorical();
        action.Should().Throw<ArgumentException>().WithMessage("Start date and end date must be provided for historical air pollution data");
    }

    [Fact]
    public void AirPollutionRequest_CanBeCreated()
    {
        // Arrange & Act
        var request = new AirPollutionRequest
        {
            ApiKey = "test-api-key",
            Latitude = 50.0,
            Longitude = 50.0,
            StartDate = DateTime.UtcNow.AddDays(-1),
            EndDate = DateTime.UtcNow
        };

        // Assert
        request.ApiKey.Should().Be("test-api-key");
        request.Latitude.Should().Be(50.0);
        request.Longitude.Should().Be(50.0);
        request.StartDate.Should().NotBeNull();
        request.EndDate.Should().NotBeNull();
    }
}