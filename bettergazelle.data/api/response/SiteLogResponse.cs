using bettergazelle.data.api.data;
using System.Text.Json.Serialization;

namespace bettergazelle.data.api.response;

[Serializable]
public class SiteLogResponse : BaseResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("response")]
    public List<SiteLogEntry> Response { get; set; }
}