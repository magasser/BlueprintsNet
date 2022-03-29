
namespace BlueprintsNet.Core.Models.Classes;

public record ObjectField : Field
{
    public ObjectField(string name,
                       AccessModifier accessModifier,
                       string objectType)
        : base(name, accessModifier, NodeType.Object)
    {
        ObjectType = objectType.MustNotBeNullOrWhiteSpace();
    }

    public string ObjectType { get; set; }
}
