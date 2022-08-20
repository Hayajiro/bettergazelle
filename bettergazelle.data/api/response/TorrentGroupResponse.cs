using bettergazelle.data.api.data;
using Newtonsoft.Json;

namespace bettergazelle.data.api.response
{
    [Serializable]
    public class TorrentGroupResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("response")]
        public TorrentGroupResponseData Response { get; set; }
    }
}