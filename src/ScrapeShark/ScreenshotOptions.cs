namespace ScrapeShark;

public sealed class ScreenshotOptions
{
    public ScreenshotOptions(string url)
    {
        Url = url;
    }

    public string Url { get; init; }
}
