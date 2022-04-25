using Microsoft.Extensions.Options;
using Microsoft.Rest;
using ScrapeShark.Client;

namespace ScrapeShark;

internal class ScrapeSharkClient : IScrapeSharkClient
{
    private readonly IScrapeSharkApi _api;
    private readonly string _apiKey;

    public ScrapeSharkClient(IScrapeSharkApi api, IOptions<ScrapeSharkOptions> options)
    {
        if (string.IsNullOrWhiteSpace(options.Value.ApiKey))
            throw new ArgumentNullException(nameof(options.Value.ApiKey), "Please provide a valid ScrapeShark API key");

        _api = api;
        _apiKey = options.Value.ApiKey;
    }

    public async Task<ScrapeResult> ScrapeAsync(ScrapeOptions options)
    {
        if (options == null)
            throw new ArgumentNullException(nameof(options));

        HttpOperationResponse? result = await _api.GetContentWithHttpMessagesAsync(options.Url, _apiKey);

        return new ScrapeResult((int)result.Response.StatusCode, await result.Response.Content.ReadAsStringAsync());
    }

    public async Task<ScreenshotResult> ScreenshotAsync(ScreenshotOptions options)
    {
        if (options == null)
            throw new ArgumentNullException(nameof(options));

        HttpOperationResponse? result = await _api.GetScreenshotWithHttpMessagesAsync(options.Url, _apiKey);

        return new ScreenshotResult((int)result.Response.StatusCode,
            await result.Response.Content.ReadAsByteArrayAsync());
    }
}
