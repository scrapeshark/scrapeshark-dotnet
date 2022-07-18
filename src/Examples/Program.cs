using System.Text.RegularExpressions;
using ScrapeShark;

IScrapeSharkClient client = new ScrapeSharkClient("");

ScrapeResult content = await client.ScrapeAsync("https://api.ipify.org/?format=raw");
ScreenshotResult screenshot = await client.ScreenshotAsync("https://scrapeshark.com");

if (content.StatusCode != 200 || screenshot.StatusCode != 200)
{
    throw new Exception(
        "Either the content scrape or screenshot was unsucessful. Make sure you are using a valid API key.");
}

Match ip = Regex.Match(content.Content, @"\b(?:[0-9]{1,3}\.){3}[0-9]{1,3}\b");

Console.WriteLine($"Proxy IP: {ip}");

await using var fs =
    new FileStream(File.OpenHandle("Screenshot.png", FileMode.Create, FileAccess.Write), FileAccess.Write);

await fs.WriteAsync(screenshot.Buffer, 0, screenshot.Buffer.Length);

Console.ReadLine();
