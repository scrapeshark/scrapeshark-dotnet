namespace ScrapeShark;

public interface IScrapeSharkClient
{
    Task<ScrapeResult> ScrapeAsync(ScrapeOptions options);

    Task<ScreenshotResult> ScreenshotAsync(ScreenshotOptions options);
}
