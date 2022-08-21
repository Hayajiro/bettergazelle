using System.Text.Json.Serialization;

namespace bettergazelle.data.api.data
{
    [Serializable]
    public class TorrentData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("releaseTitle")]
        public string ReleaseTitle { get; set; }
        
        [JsonPropertyName("freeTorrent")]
        public bool FreeTorrent { get; set; }
    }
}