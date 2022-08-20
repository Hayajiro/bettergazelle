using Newtonsoft.Json;

namespace bettergazelle.data.api.data
{
    [Serializable]
    public class TorrentData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("releaseTitle")]
        public string ReleaseTitle { get; set; }
        
        [JsonProperty("freeTorrent")]
        public bool FreeTorrent { get; set; }
    }
}