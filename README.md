![](nuget.png)

# Indiko.OpenWeatherClient
The `Indiko.OpenWeatherClient` is a .NET library for interacting with the OpenWeatherMap APIs. It provides easy access to real-time weather data and map tiles, ensuring seamless integration with .NET applications.

## Build Status
![ci](https://github.com/0xc3u/Indiko.OpenWeatherClient/actions/workflows/ci.yml/badge.svg)

## Install Controls
[![NuGet](https://img.shields.io/nuget/v/Indiko.OpenWeatherClient.svg?label=NuGet)](https://www.nuget.org/packages/Indiko.OpenWeatherClient/)

Available on [NuGet](http://www.nuget.org/packages/Indiko.OpenWeatherClient).

Install with the dotnet CLI: `dotnet add package Indiko.OpenWeatherClient`, or through the NuGet Package Manager in Visual Studio.

## Features
- Fetch current weather, hourly forecast, and daily forecast.
- Access to weather map tiles.
- Supports Dependency Injection and manual instantiation.
- Configurable through a fluent API for building request parameters.


> **Important note**:
> To use this client wrapper for openweathermap.org you need have a valid api-key from https://openweathermap.org.

## Platform supported

| Platform | Version Supported | Reference |
|----------|--------------------------|-|
| .NET | 8.0 |


## API Coverage

- Weather Data: Access current weather, hourly forecast, daily forecast. (https://openweathermap.org/api/one-call-3)
- Maps API: Retrieve specific map tiles based on geographical and zoom parameters. (https://openweathermap.org/api/weathermaps)

> For detailed API usage and more examples, please refer to the official documentation or explore the OpenWeatherClient class definitions within the package.
 

### Dependency Injection

```csharp
// Add the service to the service collection
services.AddOpenWeatherClient();
```

```csharp
// Inject the service
public class MyClass
{
    private readonly IOpenWeatherClient _openWeatherClient;

    public MyClass(IOpenWeatherClient openWeatherClient)
    {
        _openWeatherClient = openWeatherClient;
    }
}

```

### Manual instantiation

```csharp
// Create a new instance of the client
IOpenWeatherClient _openWeatherClient = new OpenWeatherClient();
```

### Usage

```csharp

// Get the current weather for a New York

var request = new OpenWeatherRequest
{
    ApiKey = "YOUR_API_KEY_HERE",
    Latitude = 40.712776,
    Longitude = -74.005974,
    Language = Constants.Languages.English,
    Unit = Constants.Units.Metric,
    Excludes = [Constants.Excludes.Minutely, Constants.Excludes.Daily, Constants.Excludes.Hourly]
};

var response = await openWeatherClient.GetWeatherAsync(request);

```


