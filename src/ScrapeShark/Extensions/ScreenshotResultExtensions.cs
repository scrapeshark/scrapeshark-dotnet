using System;
using System.IO;
using System.Threading.Tasks;

namespace ScrapeShark.Extensions
{
    public static class ScreenshotResultExtensions
    {
        public static async Task SaveToFileAsync(this ScreenshotResult result, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName));

            FileInfo fi = new FileInfo(fileName);

            if (fi.Exists)
                throw new ArgumentException($"A file with {fileName} already exists");

            await File.WriteAllBytesAsync(fileName, result.Buffer);
        }
    }
}
