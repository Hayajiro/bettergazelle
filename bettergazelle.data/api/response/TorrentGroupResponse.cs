using bettergazelle.data.api.data;
using System.Text.Json.Serialization;

namespace bettergazelle.data.api.response;

[Serializable]
public class TorrentGroupResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("response")]
    public TorrentGroupResponseData Response { get; set; }
}