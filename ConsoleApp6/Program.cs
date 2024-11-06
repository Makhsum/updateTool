using System.Diagnostics;
using System.IO.Compression;
using Microsoft.Web.Administration;

var vaersionInfo = FileVersionInfo.GetVersionInfo("C:\\Users\\MakhsumYusupov\\Downloads\\PeakboardHubOnline(8)\\Peakboard.HUB.Cloud.exe");
string filePath = Path.Combine(Path.GetTempPath(), "PeakboardHubOnline.zip");
string url = "https://downloads.peakboard.com/download/PeakboardHubOnline/dev_master/PeakboardHubOnline.zip";
HttpClient client = new HttpClient();
var res = client.GetAsync("https://peakboardpipelines.azurewebsites.net/products/PeakboardHubOnline/dev_master/version").Result;
var responceBody = res.Content.ReadAsStringAsync().Result;
//byte[] fileBytes = await client.GetByteArrayAsync(url);
//await File.WriteAllBytesAsync(filePath, fileBytes);
// EndpackFiles();
using (ServerManager serverManager = new ServerManager())
{
    foreach (var site in serverManager.Sites)
    {
        Console.WriteLine(site.Name);
    }
}
Console.WriteLine(vaersionInfo.FileVersion);


Console.ReadLine();

void EndpackFiles()
{
    string extractPath = "C:\\Users\\MakhsumYusupov\\Desktop\\test1";
    DirectoryInfo dir = new DirectoryInfo(extractPath);
    string zipData = filePath;
    foreach (FileInfo item in dir.GetFiles())
    {
        item.Delete();
    }

    foreach (DirectoryInfo directory in dir.GetDirectories())
    {
        directory.Delete(true);
    }

    ZipFile.ExtractToDirectory(zipData,extractPath);
}