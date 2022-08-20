using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace bettergazelle.data.api.data
{
    [Serializable]
    public class SiteLogEntry
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Timestamp { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}