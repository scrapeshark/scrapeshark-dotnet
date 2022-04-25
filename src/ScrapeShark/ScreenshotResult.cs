namespace ScrapeShark;

public sealed class ScreenshotResult
{
    public ScreenshotResult(int statusCode, byte[] buffer)
    {
        StatusCode = statusCode;
        Buffer = buffer;
    }

    public int StatusCode { get; }

    public byte[] Buffer { get; }
}
