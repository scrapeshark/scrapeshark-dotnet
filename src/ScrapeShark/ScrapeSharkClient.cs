using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Rest;
using ScrapeShark.Client;

namespace ScrapeShark
{
    public class ScrapeSharkClient : IScrapeSharkClient
    {
        private readonly IScrapeSharkApi _api;
        private readonly string _apiKey;

        internal ScrapeSharkClient(IScrapeSharkApi api, IOptions<ScrapeSharkOptions> options)
        {
            if (string.IsNullOrWhiteSpace(options.Value.ApiKey))
                throw new ArgumentNullException(nameof(options.Value.ApiKey), "Please provide a valid ScrapeShark API key");

            _api = api;
            _apiKey = options.Value.ApiKey;
        }

        public ScrapeSharkClient(string apiKey)
        {
            _api = new ScrapeSharkApi(new Uri("https://api.scrapeshark.com/v1/", UriKind.Absolute));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public async Task<ScrapeResult> ScrapeAsync(ScrapeOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            HttpOperationResponse? result = await _api.GetContentWithHttpMessagesAsync(options.Url, _apiKey,
                browser: options.Browser, includeImages: options.IncludeImages,
                includeJavaScript: options.IncludeJavaScript, includeStyleSheets: options.IncludeStyleSheets,
                waitMilliseconds: options.WaitDuration.Milliseconds, elementSelector: options.ElementSelector);

            return new ScrapeResult((int)result.Response.StatusCode, await result.Response.Content.ReadAsStringAsync());
        }

        public async Task<ScreenshotResult> ScreenshotAsync(ScreenshotOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            HttpOperationResponse? result = await _api.GetScreenshotWithHttpMessagesAsync(options.Url, _apiKey,
                isFullPage: options.IsFullPage, elementSelector: options.ElementSelector, browser: options.Browser,
                waitMilliseconds: options.WaitDuration.Milliseconds);

            return new ScreenshotResult((int)result.Response.StatusCode,
                await result.Response.Content.ReadAsByteArrayAsync());
        }
    }

}
