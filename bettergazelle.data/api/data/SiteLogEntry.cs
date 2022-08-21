using System.Text.Json.Serialization;

namespace bettergazelle.data.api.data
{
    [Serializable]
    public class SiteLogEntry
    {
        [JsonPropertyName("id"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int Id { get; set; }

        [JsonPropertyName("time"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTimeOffset Timestamp { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}