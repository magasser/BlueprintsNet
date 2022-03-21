
namespace BlueprintsNet.Core.Models.Classes;

public record Parameter
{
    public Parameter(string name, Type type)
    {
        Name = name.MustNotBeNullOrWhiteSpace();
        Type = type.MustNotBeNull();
    }

    public string Name { get; set; }

    public Type Type { get; set; }
}
