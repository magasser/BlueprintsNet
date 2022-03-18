using BlueprintsNet.Core.Models.Project;

namespace BlueprintsNet.Core.Services;

public interface IProjectService
{
    Project LoadProject(string path);

    void SaveProject(Project project);

    Class LoadClass(string path);

    void SaveClass(Class @class);
}
