using bettergazelle.data.api.data;
using Newtonsoft.Json;

namespace bettergazelle.data.api.response
{
    public class CollectionResponse : BaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("response")]
        public CollectionData Response { get; set; }
    }
}