using bettergazelle.data.api.data;
using Newtonsoft.Json;

namespace bettergazelle.data.api.response{
    [Serializable]
    public class SiteLogResponse : BaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("response")]
        public List<SiteLogEntry> Response { get; set; }
    }
}