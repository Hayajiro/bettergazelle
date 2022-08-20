using Newtonsoft.Json;

namespace bettergazelle.data.api.data
{
    [Serializable]
    public class TorrentGroupData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}