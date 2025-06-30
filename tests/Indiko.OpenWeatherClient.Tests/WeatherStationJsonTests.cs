using System.Text.Json;
using FluentAssertions;

namespace Indiko.OpenWeatherClient.Tests;

public class WeatherStationJsonTests
{
    [Fact]
    public void WeatherStationRequest_SerializesToExpectedJson()
    {
        // Arrange
        var requestData = new
        {
            external_id = "SF_TEST001",
            name = "San Francisco Test Station",
            latitude = 37.76,
            longitude = -122.43,
            altitude = 150.0
        };

        // Act
        var json = JsonSerializer.Serialize(requestData);
        var deserializedData = JsonSerializer.Deserialize<JsonElement>(json);

        // Assert
        deserializedData.GetProperty("external_id").GetString().Should().Be("SF_TEST001");
        deserializedData.GetProperty("name").GetString().Should().Be("San Francisco Test Station");
        deserializedData.GetProperty("latitude").GetDouble().Should().Be(37.76);
        deserializedData.GetProperty("longitude").GetDouble().Should().Be(-122.43);
        deserializedData.GetProperty("altitude").GetDouble().Should().Be(150.0);
    }
}