namespace Indiko.OpenWeatherClient.Exceptions;

/// <summary>
/// Represents errors that occur during OpenWeather API operations.
/// </summary>
public sealed class OpenWeatherException(int statusCode, string responseMessage) : Exception(responseMessage)
{
    /// <summary>
    /// Gets the HTTP status code returned from the OpenWeather API when the error occurred.
    /// </summary>
    public int ResponseCode { get; } = statusCode;

    /// <summary>
    /// Gets the message describing the error, as returned by the OpenWeather API.
    /// </summary>
    public string ResponseMessage { get; } = responseMessage;
}