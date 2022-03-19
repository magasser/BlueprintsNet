
namespace BlueprintsNet.Core.Services;

public interface IFileService
{
    string Read(string path);

    void Write(string path, string content);
}
