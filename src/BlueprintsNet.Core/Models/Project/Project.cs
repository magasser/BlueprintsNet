
namespace BlueprintsNet.Core.Models;

public class Project
{
    public Project(Guid id,
                   string name,
                   string path,
                   IEnumerable<Class> classes)
    {
        Id = id.MustNotBeDefault();
        Name = name.MustNotBeNullOrWhiteSpace();
        Path = path.MustNotBeNullOrWhiteSpace();
        Classes = classes.MustNotBeNull()
                      .ToList();
    }

    public Guid Id { get; }

    public string Name { get; set; }

    public string Path { get; set; }

    public List<Class> Classes { get; }
}
