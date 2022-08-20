using System.Text.RegularExpressions;
using bettergazelle.apiclient;
using bettergazelle.data.api.data;

namespace bettergazelle.freeleecher;

public class LogScraper
{
    private const string LastLogIdFile = "lastlog.id";
    private readonly GazelleClient _client;
    private int _lastLogId;
    private readonly Regex _regex;

    public LogScraper(GazelleClient client)
    {
        _client = client;
        if (File.Exists(LastLogIdFile))
        {
            _lastLogId = int.Parse(File.ReadAllText(LastLogIdFile));
        }

        _regex = new Regex("Torrent Group (?<id>[0-9]+) \\(.*>(?<name>.+)</a>.*");
    }

    public IEnumerable<int> GrabFreeleechTorrentGroups()
    {
        var data = _client.GetSiteLog(search: "was put on pot freeleech").Result;

        if (data?.Response != null)
        {
            foreach (SiteLogEntry entry in data.Response.Where(s => s.Id > _lastLogId).OrderBy(s => s.Id))
            {
                Match match = _regex.Match(entry.Message);

                if (match.Success)
                {
                    int torrentGroupId = int.Parse(match.Groups["id"].Value);
                    yield return torrentGroupId;

                    Console.WriteLine($"[{entry.Id}][{entry.Timestamp}]{entry.Message}");
                    _lastLogId = entry.Id;
                    File.WriteAllText(LastLogIdFile, _lastLogId.ToString());
                }
                else
                {
                    throw new Exception($"Error parsing input: {entry.Message}");
                }
            }
        }
    }
}