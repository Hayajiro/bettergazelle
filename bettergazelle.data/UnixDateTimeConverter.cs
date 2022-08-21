using System.Text.Json;
using System.Text.Json.Serialization;

namespace bettergazelle.data;

public class UnixDateTimeConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        long timestamp = reader.TokenType == JsonTokenType.Number
            ? reader.GetInt64()
            : long.Parse(reader.GetString()!);

        return DateTimeOffset.FromUnixTimeSeconds(timestamp);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}