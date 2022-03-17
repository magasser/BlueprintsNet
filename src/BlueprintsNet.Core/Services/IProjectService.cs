
namespace BlueprintsNet.Core.Services;

public interface IProjectService
{
    Project LoadProject(string projectPath);

    void SaveClass(Class @class);
}
