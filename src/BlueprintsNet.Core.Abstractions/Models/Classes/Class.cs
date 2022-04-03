
namespace BlueprintsNet.Core.Models.Classes;

public class Class
{
    private readonly List<BlueprintReference> _blueprintReferences;

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

        _blueprintReferences = new List<BlueprintReference>();
    }

    public string FolderPath { get; set; }

    public IReadOnlyList<BlueprintReference> BlueprintReferences => _blueprintReferences;

    public string Name { get; set; }

    public string Namespace { get; set; }

    public List<string> Usings { get; init; }

    public AccessModifier AccessModifier { get; set; }

    public List<Constructor> Constructors { get; init; }

    public List<Field> Fields { get; init; }

    public List<Method> Methods { get; init; }

    public void AddReference(IBlueprint blueprint, IEntryPoint parent)
    {
        blueprint.MustNotBeNull();

        _blueprintReferences.Add(new BlueprintReference(new Guid(), blueprint, parent));
    }

    public void RemoveReference(IBlueprint blueprint)
    {
        blueprint.MustNotBeNull();

        var reference = _blueprintReferences.SingleOrDefault(x => x.Blueprint == blueprint);

        if (reference is null)
        {
            return;
        }

        _blueprintReferences.Remove(reference);
    }
}
