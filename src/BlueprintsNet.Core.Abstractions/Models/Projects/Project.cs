
namespace BlueprintsNet.Core.Models.Projects;

public class Project
{
    public Project(Guid id,
                   string name,
                   string folderPath,
                   IEnumerable<Class> classes)
    {
        Id = id.MustNotBeDefault();
        Name = name.MustNotBeNullOrWhiteSpace();
        FolderPath = folderPath.MustNotBeNullOrWhiteSpace();
        Classes = classes.MustNotBeNull()
                      .ToList();
    }

    public Guid Id { get; init; }

    public string Name { get; set; }

    public string FolderPath { get; set; }

    public List<Class> Classes { get; init; }
}
