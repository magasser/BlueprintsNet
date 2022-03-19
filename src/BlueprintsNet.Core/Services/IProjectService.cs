using BlueprintsNet.Core.Models.Project;

namespace BlueprintsNet.Core.Services;

public interface IProjectService
{
    Class LoadClass(string path);

    void SaveClass(Class @class);

    Project LoadProject(string path);

    void SaveProject(Project project);
}
