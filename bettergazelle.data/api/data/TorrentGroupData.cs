using System.Text.Json.Serialization;

namespace bettergazelle.data.api.data
{
    [Serializable]
    public class TorrentGroupData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}