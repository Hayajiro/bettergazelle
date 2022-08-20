using Newtonsoft.Json;

namespace bettergazelle.data.api.data
{
    [Serializable]
    public class TorrentGroupResponseData
    {
        [JsonProperty("group")]
        public TorrentGroupData TorrentGroupData { get; set; }
        
        [JsonProperty("torrents")]
        public List<TorrentData> Torrents { get; set; }
    }
}