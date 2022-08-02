# ScrapeShark .NET

This repository contains the code for the ScrapeShark client library for .NET. ScrapeShark allows you to retrieve the content of a web page, or capture a screenshot of a page with a single line of code.

You can grab the latest version directly from NuGet:

```
nuget install ScrapeShark
```

# Usage

After installing the client library, create a new client using your API key:

```csharp
IScrapeSharkClient client = new ScrapeSharkClient("<YOUR API KEY>");
```

If you don't have an API key yet, you can obtain one from your [Account Dashboard](https://dashboard.scrapeshark.com/account/keys).

## Scrape Content

Using ScrapeShark, you can capture the content of a web page with a single line of code, while also ensuring any JavaScript is rendered, and your request is well hidden behind multiple proxies:

```csharp
ScrapeResult content = await client.ScrapeAsync("https://api.ipify.org/?format=raw");
```

The `ScrapeResult` will contain the status code, and content if the request was successful. For more information on some of the techniques we employ, visit our [Web Scraping Without Getting Blocked](https://scrapeshark.com/blog/web-scraping-without-getting-blocked) article.

## Capture Screenshot

Capturing a screenshot is easy:

```csharp
ScreenshotResult screenshot = await client.ScreenshotAsync("https://scrapeshark.com");
```

The `ScreenshotResult` will contain the response status code, and if successful, a buffer containing the screenshot captured. To save the screenshot, simply call `SaveToFileAsync`:

```csharp
await screenshot.SaveToFileAsync("Screenshot.png");
```

## Documentation

For more information on our API, as well as elaborate documentation, please refer to the [ScrapeShark API Documentation](https://scrapeshark.com/docs/intro).

# Contributions

If you have anything useful, or you're missing something in the library, feel free to make a contribution. Feature requests are most welcome through issues, and code contributions through pull requests.

When making a code contribution, please stay in line with the coding conventions already present in the codebase. We strongly favour consistency when it comes to code.
