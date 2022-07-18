namespace ScrapeShark;

public interface IScrapeSharkClient
{
    Task<ScrapeResult> ScrapeAsync(ScrapeOptions options);

    Task<ScrapeResult> ScrapeAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentNullException(nameof(url));

        return ScrapeAsync(new ScrapeOptions(url));
    }

    Task<ScreenshotResult> ScreenshotAsync(ScreenshotOptions options);

    Task<ScreenshotResult> ScreenshotAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentNullException(nameof(url));

        return ScreenshotAsync(new ScreenshotOptions(url));
    }
}
