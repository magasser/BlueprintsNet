
namespace BlueprintsNet.Core.Services;

public interface IFileService
{
    void Write(string path, string content);

    string Read(string path);
}
