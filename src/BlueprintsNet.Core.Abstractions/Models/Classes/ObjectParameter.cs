
namespace BlueprintsNet.Core.Models.Classes;

public record ObjectParameter : Parameter
{
    public ObjectParameter(string name, string objectType)
        : base(name, NodeType.Object)
    {
        ObjectType = objectType.MustNotBeNullOrWhiteSpace();
    }

    public string ObjectType { get; set; }
}
