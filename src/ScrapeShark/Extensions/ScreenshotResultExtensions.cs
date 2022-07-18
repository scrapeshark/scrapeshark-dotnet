namespace ScrapeShark.Extensions;

public static class ScreenshotResultExtensions
{
    public static async Task SaveToFileAsync(this ScreenshotResult result, string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentNullException(nameof(fileName));

        var fi = new FileInfo(fileName);

        if (fi.Exists)
            throw new ArgumentException($"A file with {fileName} already exists");

        await using var fs =
            new FileStream(File.OpenHandle(fileName, FileMode.CreateNew, FileAccess.Write), FileAccess.Write);

        await fs.WriteAsync(result.Buffer, 0, result.Buffer.Length);
    }
}
