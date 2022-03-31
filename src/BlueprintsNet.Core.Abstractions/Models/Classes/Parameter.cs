
namespace BlueprintsNet.Core.Models.Classes;

public record Parameter
{
    public Parameter(string name, NodeType nodeType)
    {
        Name = name.MustNotBeNullOrWhiteSpace();
        NodeType = nodeType.MustBeValidEnumValue();
    }

    public string Name { get; set; }

    public NodeType NodeType { get; set; }
}
