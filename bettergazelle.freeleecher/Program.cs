using bettergazelle.apiclient;
using bettergazelle.freeleecher;

string watchFolder = string.Empty;
if (args.Length == 1)
{
    watchFolder = args[0];
}
else
{
    Console.WriteLine("No watchFolder specified!");
    Environment.Exit(-1);
}

string appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "bettergazelle");
Directory.CreateDirectory(appdata);
Directory.SetCurrentDirectory(appdata);

string[] ggnKeys = File
    .ReadAllText("ggn.apitoken")
    .Split(Environment.NewLine);

GazelleClient client = new(ggnKeys[0]);
string authKey = ggnKeys[1];
string torrentPassword = ggnKeys[2];

LogScraper scraper = new(client);
int scrapeDelay = 5 * 60 * 1000;
FreeleechDownloader downloader = new(client, authKey, torrentPassword, watchFolder);

Console.WriteLine("Hello, Gazellians!");

while (true)
{
    int currentDelay = scrapeDelay;
    try
    {
        foreach (int i in scraper.GrabFreeleechTorrentGroups())
        {
            currentDelay -= downloader.DownloadTorrentGroup(i);
        }
        
        downloader.PersistDatabase();
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error while fetching new FL games: {e.Message}");
    }

    Thread.Sleep(currentDelay);
}