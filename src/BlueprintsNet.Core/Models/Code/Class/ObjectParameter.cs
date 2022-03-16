
namespace BlueprintsNet.Core.Models.Code;

public record ObjectParameter : Parameter
{
    public ObjectParameter(string name, string objectType)
        : base(name, typeof(Blueprints.Object))
    {
        ObjectType = objectType.MustNotBeNullOrWhiteSpace();
    }

    public string ObjectType { get; set; }
}
