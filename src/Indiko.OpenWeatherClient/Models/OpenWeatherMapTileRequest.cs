using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indiko.OpenWeatherClient.Models;
public record OpenWeatherMapTileRequest
{
    public string ApiKey { get; init; }
    public string Layer { get; init; }
    public int ZoomLevel { get; init; }
    public int X { get; init; }
    public int Y { get; init; }
}
