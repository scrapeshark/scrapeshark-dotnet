using System;

namespace ScrapeShark
{
    public sealed class ScrapeOptions
    {
        public ScrapeOptions(string url)
        {
            Url = url;
        }

        public string Url { get; set; }

        public string Browser { get; set; } = "Chromium";

        public bool IncludeJavaScript { get; set; } = true;

        public bool IncludeStyleSheets { get; set; } = false;

        public bool IncludeImages { get; set; } = false;

        public TimeSpan WaitDuration { get; set; } = TimeSpan.Zero;

        public string? ElementSelector { get; set; } = null;
    }
}
