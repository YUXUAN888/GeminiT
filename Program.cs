using GeminiT.MainCore.GeminiF;
using GeminiT.Version;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

class Program
{
    public class IconData
    {
        public string hash { get; set; }
        public int size { get; set; }
    }

    public class RootObject
    {
        public Dictionary<string, IconData> objects { get; set; }
    }
    static async Task Main(string[] args)
    {
        Console.WriteLine("GeminiCore 1[beta]");
        Console.WriteLine("GeminiCore is open source with GPL-3 protocol, authored by Yu_Xuan.");
        List<string> downloadUrls = new List<string>();                              //download address
        List<string> downloadDirectories = new List<string>();                       //download directories
        Console.WriteLine("Please select the version you want to download, source is MCBBS.");
        Console.WriteLine("loading..");
        HttpClient client = new HttpClient();
        string s1 = await client.GetStringAsync("https://download.mcbbs.net/mc/game/version_manifest_v2.json");
        Root ss1 = JsonConvert.DeserializeObject<Root>(s1);
        for(int i = ss1.versions.Count - 1; i > 0; --i)
        {
            Console.WriteLine(i.ToString()+". "+ss1.versions[i].id);
        }
        Console.WriteLine("Choose:");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("Where:");
        string downloadDirectory = Console.ReadLine();
        Directory.CreateDirectory(downloadDirectory + @"\versions\" + ss1.versions[num].id);
        WebClient we = new();
        we.DownloadFile(ss1.versions[num].url, downloadDirectory + @"\versions\" + ss1.versions[num].id +@"\"+ ss1.versions[num].id+".json");
        JsonX.Root ss2 = JsonConvert.DeserializeObject<JsonX.Root>(File.ReadAllText(downloadDirectory + @"\versions\" + ss1.versions[num].id + @"\" + ss1.versions[num].id + ".json"));
        Directory.CreateDirectory(downloadDirectory + @"\assets\indexes");
        we.DownloadFile(ss2.assetIndex.url, downloadDirectory + @"\assets\indexes\" + ss2.assetIndex.id + ".json");
        string Jsonfile = downloadDirectory + @"\versions\" + ss1.versions[num].id + @"\" + ss1.versions[num].id + ".json";
        string AssetsJson = downloadDirectory + @"\assets\indexes\" + ss2.assetIndex.id + ".json";
        RootObject data = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(AssetsJson));
        // 获取所有项的hash值
        Dictionary<string, string> allHashValues = new Dictionary<string, string>();
        foreach (var item in data.objects)
        {
            allHashValues[item.Key] = item.Value.hash;
        }
        Directory.CreateDirectory(downloadDirectory + @"\assets\objects");
        //hash
        foreach (var kvp in allHashValues)
        {
            downloadUrls.Add("https://download.mcbbs.net/assets/" + kvp.Value.Substring(0, 2) + @"/" + kvp.Value);
            if(!Directory.Exists(downloadDirectory + @"\assets\objects\" + kvp.Value.Substring(0, 2)))
            {
                Directory.CreateDirectory(downloadDirectory + @"\assets\objects\" + kvp.Value.Substring(0, 2));
            }
            downloadDirectories.Add(downloadDirectory + @"\assets\objects\" + kvp.Value.Substring(0, 2) +@"\");
        }
        //Download
        int maxParallelDownloads = 3; // Maximum concurrent downloads

        var cts = new CancellationTokenSource();
        var downloadTasks = new List<Task>();

        var progress = new Progress<double>(percent =>
        {
            Console.WriteLine($"Download Progress: {percent}%");
        });

        try
        {

            await Task.WhenAll(
                downloadUrls
                    .ToChunks(maxParallelDownloads)
                    .Select((chunk, index) => GeminiCoreQ.DownloadFilesAsync(chunk, downloadDirectories[index], cts.Token, progress))
                    .ToArray()
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            cts.Cancel(); // Cancel all downloads if there's an error
            cts.Dispose();
        }

        Console.WriteLine("All downloads completed.");

    }
}
