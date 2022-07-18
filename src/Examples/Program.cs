using System.Text.RegularExpressions;
using ScrapeShark;
using ScrapeShark.Extensions;

IScrapeSharkClient client = new ScrapeSharkClient("sh_RxIVVPsqaCzKvfBCtw1LfQ7M1v9B1Lw7");

ScrapeResult content = await client.ScrapeAsync("https://api.ipify.org/?format=raw");
ScreenshotResult screenshot = await client.ScreenshotAsync("https://scrapeshark.com");

if (content.StatusCode != 200 || screenshot.StatusCode != 200)
{
    throw new Exception(
        "Either the content scrape or screenshot was unsucessful. Make sure you are using a valid API key.");
}

Match ip = Regex.Match(content.Content, @"\b(?:[0-9]{1,3}\.){3}[0-9]{1,3}\b");

Console.WriteLine($"Proxy IP: {ip}");

await screenshot.SaveToFileAsync("Screenshot.png");

Console.ReadLine();
