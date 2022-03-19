
namespace BlueprintsNet.Core.Services;

internal class FileService : IFileService
{
    public readonly ILogger<FileService> _logger;

    public FileService(ILogger<FileService> logger)
    {
        _logger = logger.MustNotBeNull();
    }

    public string Read(string path)
    {
        path.MustNotBeNullOrWhiteSpace();

        _logger.LogTrace("Try to read file content from path: {Path}.", path);

        var result = File.ReadAllText(path);

        _logger.LogDebug("Read content at {Path}: {Content}.", path, result);

        return result;
    }

    public void Write(string path, string content)
    {
        path.MustNotBeNullOrWhiteSpace();
        content.MustNotBeNullOrWhiteSpace();

        _logger.LogTrace("Try to write file content at {Path}: {Content}.", path, content);

        File.WriteAllText(path, content);

        _logger.LogDebug("Wrote file content to {Path}: {Content}.", path, content);
    }
}
