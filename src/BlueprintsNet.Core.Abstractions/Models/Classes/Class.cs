
namespace BlueprintsNet.Core.Models.Classes;

public class Class
{
    public Class() { }

    public Class(string name,
                 string folderPath,
                 AccessModifier accessModifier)
    {
        Name = name.MustNotBeNullOrWhiteSpace();
        FolderPath = folderPath.MustNotBeNullOrWhiteSpace();
        AccessModifier = accessModifier.MustBeValidEnumValue();

        Constructors = new List<Constructor>();
        Fields = new List<Field>();
        Methods = new List<Method>();
    }

    public string Name { get; set; }

    public string FolderPath { get; set; }

    public AccessModifier AccessModifier { get; set; }

    public List<Constructor> Constructors { get; init; }

    public List<Field> Fields { get; init; }

    public List<Method> Methods { get; init; }
}
