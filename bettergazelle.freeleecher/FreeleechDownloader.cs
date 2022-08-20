using bettergazelle.apiclient;
using bettergazelle.data.api.data;
using bettergazelle.data.api.response;

namespace bettergazelle.freeleecher;

public class FreeleechDownloader
{
    private const string DownloadedTorrentsFile = "downloaded_torrents.lst";
    private readonly GazelleClient _client;
    private readonly string _authKey;
    private readonly string _torrentPass;
    private readonly string _watchFolder;
    private readonly int _apiDelay;
    private readonly int _torrentDelay;
    private readonly Dictionary<int, bool> _torrentDatabase;

    public FreeleechDownloader(GazelleClient client, string authKey, string torrentPass, string watchFolder, int apiDelay = 2500, int torrentDelay = 200)
    {
        _client = client;
        _authKey = authKey;
        _torrentPass = torrentPass;
        _watchFolder = watchFolder;
        _apiDelay = apiDelay;
        _torrentDelay = torrentDelay;
        _torrentDatabase = new Dictionary<int, bool>();

        if (!Directory.Exists(watchFolder))
        {
            Directory.CreateDirectory(watchFolder);
        }

        if (File.Exists(DownloadedTorrentsFile))
        {
            string[] lines = File.ReadAllLines(DownloadedTorrentsFile);
            foreach (string s in lines)
            {
                _torrentDatabase.Add(int.Parse(s), true);
            }
        }
    }

    public int DownloadTorrentGroup(int groupId)
    {
        Console.WriteLine($"Fetching torrent group {groupId}");
        TorrentGroupResponse? torrentGroup = _client.GetTorrentGroup(groupId).Result;

        if (torrentGroup == null)
        {
            return 0;
        }

        foreach (TorrentData torrent in torrentGroup.Response.Torrents)
        {
            DownloadTorrent(torrent);
        }

        int finalDelay = _apiDelay - torrentGroup.Response.Torrents.Count * _torrentDelay;

        if (finalDelay > 0)
        {
            Thread.Sleep(finalDelay);
            return _apiDelay;
        }

        return Math.Abs(finalDelay) + _apiDelay;
    }

    public void PersistDatabase()
    {
        Console.WriteLine("Persisting database...");
        File.WriteAllLines(DownloadedTorrentsFile, _torrentDatabase.Keys.Select(s => s.ToString()));
    }

    private void DownloadTorrent(TorrentData torrent)
    {
        if (torrent.FreeTorrent && IsNewTorrent(torrent.Id))
        {
            Console.WriteLine($"Grabbing [{torrent.Id}]{torrent.ReleaseTitle}...");

            File.WriteAllBytes(Path.Combine(_watchFolder, $"{torrent.Id}.torrent"),
                _client.GetTorrent(torrent.Id, _authKey, _torrentPass).Result);
            _torrentDatabase.Add(torrent.Id, true);
            Thread.Sleep(_torrentDelay);
        }
    }

    private bool IsNewTorrent(int torrentId)
    {
        return !_torrentDatabase.ContainsKey(torrentId);
    }
}