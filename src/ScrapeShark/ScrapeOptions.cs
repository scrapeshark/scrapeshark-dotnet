namespace ScrapeShark;

public sealed class ScrapeOptions
{
    public ScrapeOptions(string url)
    {
        Url = url;
    }

    public string Url { get; init; }
}
