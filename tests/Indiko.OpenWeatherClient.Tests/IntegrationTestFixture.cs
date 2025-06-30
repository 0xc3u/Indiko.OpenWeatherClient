namespace Indiko.OpenWeatherClient.Tests;
public class IntegrationTestFixture : IDisposable
{

    public string ApiKey { get; }

    public OpenWeatherClient OpenWeatherClient { get; }

    public IntegrationTestFixture()
    {
        // Initialize the test environment
        OpenWeatherClient = new OpenWeatherClient();
        ApiKey = "9b9b5f227e0b929c76caa1a14fdf56a5";
    }

    public void Dispose()
    {
        // Clean up the test environment
        OpenWeatherClient.Dispose();
    }
}
