using System;

namespace ScrapeShark
{
    public sealed class ScreenshotOptions
    {
        public ScreenshotOptions(string url)
        {
            Url = url;
        }

        public string Url { get; set; }

        public bool IsFullPage { get; set; } = false;

        public string Browser { get; set; } = "Chromium";

        public TimeSpan WaitDuration { get; set; } = TimeSpan.Zero;

        public string? ElementSelector { get; set; } = null;
    }
}
