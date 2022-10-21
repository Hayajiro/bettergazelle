using bettergazelle.apiclient;
using bettergazelle.freeleecher;

if (args.Length < 1)
{
    Console.WriteLine("No watch folder specified!");
    Environment.Exit(-1);
}

string watchFolder = args[0];
string tokenFile   = args.Length >= 2
    ? args[1]
    : "ggn.tokens";

string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "bettergazelle");
Directory.CreateDirectory(appData);
Directory.SetCurrentDirectory(appData);

string[] ggnKeys = File.ReadAllText(tokenFile)
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