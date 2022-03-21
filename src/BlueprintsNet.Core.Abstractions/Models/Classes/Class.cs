
namespace BlueprintsNet.Core.Models.Classes;

public class Class
{
    private Class() { }

    public Class(string name,
                 string @namespace,
                 string folderPath,
                 AccessModifier accessModifier)
    {
        Name = name.MustNotBeNullOrWhiteSpace();
        Namespace = @namespace.MustNotBeNullOrWhiteSpace();
        FolderPath = folderPath.MustNotBeNullOrWhiteSpace();
        AccessModifier = accessModifier.MustBeValidEnumValue();

        Usings = new List<string>();
        Constructors = new List<Constructor>();
        Fields = new List<Field>();
        Methods = new List<Method>();
    }

    public string FolderPath { get; set; }

    public string Name { get; set; }

    public string Namespace { get; set; }

    public List<string> Usings { get; init; }

    public AccessModifier AccessModifier { get; set; }

    public List<Constructor> Constructors { get; init; }

    public List<Field> Fields { get; init; }

    public List<Method> Methods { get; init; }
}
