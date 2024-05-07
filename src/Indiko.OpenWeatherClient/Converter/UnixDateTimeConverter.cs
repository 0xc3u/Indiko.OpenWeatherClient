using System.Text.Json;
using System.Text.Json.Serialization;

namespace Indiko.OpenWeatherClient.Converter;

/// <summary>
/// A custom JSON converter that converts between Unix timestamps and nullable DateTime objects.
/// This converter handles the conversion of DateTime values to and from Unix timestamps in JSON.
/// </summary>
public class UnixDateTimeConverter : JsonConverter<DateTime?>
{
    /// <summary>
    /// Reads and converts the JSON token into a nullable DateTime value.
    /// </summary>
    /// <param name="reader">The reader to read from.</param>
    /// <param name="typeToConvert">The type of object to convert.</param>
    /// <param name="options">Options for the serializer.</param>
    /// <returns>A DateTime value if the JSON token is a number; otherwise, null.</returns>
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            long unixTime = reader.GetInt64();
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).UtcDateTime;
        }
        return null;
    }

    /// <summary>
    /// Writes a DateTime value as a Unix timestamp to the JSON writer.
    /// </summary>
    /// <param name="writer">The writer to write to.</param>
    /// <param name="value">The DateTime value to write.</param>
    /// <param name="options">Options for the serializer.</param>
    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            long unixTime = ((DateTimeOffset)value.Value).ToUnixTimeSeconds();
            writer.WriteNumberValue(unixTime);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
