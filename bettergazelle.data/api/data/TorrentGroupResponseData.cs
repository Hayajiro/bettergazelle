using System.Text.Json.Serialization;

namespace bettergazelle.data.api.data
{
    [Serializable]
    public class TorrentGroupResponseData
    {
        [JsonPropertyName("group")]
        public TorrentGroupData TorrentGroupData { get; set; }
        
        [JsonPropertyName("torrents")]
        public List<TorrentData> Torrents { get; set; }
    }
}