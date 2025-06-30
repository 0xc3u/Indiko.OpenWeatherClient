using Indiko.OpenWeatherClient.Models;
using FluentAssertions;
using System.Text.Json;

namespace Indiko.OpenWeatherClient.Tests;

public class AirPollutionModelTests
{
    [Fact]
    public void AirPollutionResponse_CanDeserializeFromJson()
    {
        // Arrange
        var json = @"{
          ""coord"": [50, 50],
          ""list"": [
            {
              ""dt"": 1605182400,
              ""main"": {
                ""aqi"": 1
              },
              ""components"": {
                ""co"": 201.94053649902344,
                ""no"": 0.01877197064459324,
                ""no2"": 0.7711350917816162,
                ""o3"": 68.66455078125,
                ""so2"": 0.6407499313354492,
                ""pm2_5"": 0.5,
                ""pm10"": 0.540438711643219,
                ""nh3"": 0.12369127571582794
              }
            }
          ]
        }";

        // Act
        var response = JsonSerializer.Deserialize<AirPollutionResponse>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        // Assert
        response.Should().NotBeNull();
        response.Coord.Should().HaveCount(2);
        response.Coord[0].Should().Be(50);
        response.Coord[1].Should().Be(50);
        
        response.List.Should().HaveCount(1);
        
        var airPollutionData = response.List[0];
        airPollutionData.Should().NotBeNull();
        airPollutionData.Main.Should().NotBeNull();
        airPollutionData.Main.Aqi.Should().Be(1);
        
        airPollutionData.Components.Should().NotBeNull();
        airPollutionData.Components.Co.Should().BeApproximately(201.94, 0.01);
        airPollutionData.Components.No.Should().BeApproximately(0.018, 0.01);
        airPollutionData.Components.No2.Should().BeApproximately(0.771, 0.01);
        airPollutionData.Components.O3.Should().BeApproximately(68.66, 0.01);
        airPollutionData.Components.So2.Should().BeApproximately(0.640, 0.01);
        airPollutionData.Components.Pm2_5.Should().Be(0.5);
        airPollutionData.Components.Pm10.Should().BeApproximately(0.540, 0.01);
        airPollutionData.Components.Nh3.Should().BeApproximately(0.123, 0.01);
    }
}