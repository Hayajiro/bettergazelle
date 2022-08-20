using bettergazelle.data.api.data;
using System.Text.Json.Serialization;

namespace bettergazelle.data.api.response;

public class CollectionResponse : BaseResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("response")]
    public CollectionData Response { get; set; }
}