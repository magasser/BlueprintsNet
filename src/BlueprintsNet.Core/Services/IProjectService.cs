using BlueprintsNet.Core.Models.Projects;

namespace BlueprintsNet.Core.Services;

public interface IProjectService
{
    Class LoadClass(string name, string folderPath);

    void SaveClass(Class @class);

    Project LoadProject(string name, string folderPath);

    void SaveProject(Project project);
}
