namespace ScrapeShark;

public sealed class ScrapeResult
{
    public ScrapeResult(int statusCode, string content)
    {
        StatusCode = statusCode;
        Content = content;
    }

    public int StatusCode { get; }

    public string Content { get; }
}
