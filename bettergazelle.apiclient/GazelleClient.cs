using bettergazelle.data.api.response;
using System.Text.Json;

namespace bettergazelle.apiclient;

public class GazelleClient
{
    private readonly HttpClient _httpClient;

    public GazelleClient(string apiToken)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://gazellegames.net"),
            DefaultRequestHeaders = 
            {
                { "X-API-Key", apiToken }
            }
        };
    }

    public async Task<SiteLogResponse?> GetSiteLog(int page = 1, int limit = 25, string? search = default)
    {
        string responseData = await _httpClient.GetStringAsync("/api.php?request=sitelog" +
                                                               $"&page={page}" +
                                                               $"&limit={limit}" +
                                                               $"{(search == default ? "" : $"&search={search}")}"
        );

        SiteLogResponse? response = JsonSerializer.Deserialize<SiteLogResponse>(responseData);

        return response;
    }

    public async Task<CollectionResponse?> GetCollection(int id)
    {
        string responseData = await _httpClient.GetStringAsync("/api.php?request=collection" +
                                                               $"&id={id}"
        );

        CollectionResponse? response = JsonSerializer.Deserialize<CollectionResponse>(responseData);

        return response;
    }

    public async Task<TorrentGroupResponse?> GetTorrentGroup(int id)
    {
        string responseData = await _httpClient.GetStringAsync("/api.php?request=torrentgroup" +
                                                               $"&id={id}"
        );

        TorrentGroupResponse? response = JsonSerializer.Deserialize<TorrentGroupResponse>(responseData);

        return response;
    }

    public async Task<byte[]> GetTorrent(int id, string authKey, string torrentPassword)
    {
        return await _httpClient.GetByteArrayAsync("/torrents.php?action=download" +
                                                               $"&id={id}" +
                                                               $"&authkey={authKey}" +
                                                               $"&torrent_pass={torrentPassword}"
        );
    }
}