namespace Indiko.OpenWeatherClient.Tests;
public class IntegrationTestFixture : IDisposable
{

    public string ApiKey { get; }

    public OpenWeatherClient OpenWeatherClient { get; }

    public IntegrationTestFixture()
    {
        // Initialize the test environment
        OpenWeatherClient = new OpenWeatherClient();
        ApiKey = "332323232323232323";
    }

    public void Dispose()
    {
        // Clean up the test environment
        OpenWeatherClient.Dispose();
    }
}
