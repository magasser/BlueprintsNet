
namespace BlueprintsNet.Core.Models.Blueprints;

public class Object : ValueBase
{
    private Object(IBlueprint parent,
                   string displayName,
                   string objectType)
        : base(parent, displayName)
    {
        ObjectType = objectType.MustNotBeNullOrWhiteSpace();
        DataType = NodeType.Object;
    }

    private Object(IBlueprint parent, string objectType)
        : this(parent, string.Empty, objectType)
    {
        DataType = NodeType.Object;
    }

    public string ObjectType { get; init; }

    public override NodeType DataType { get; init; }

    public class In : Object, IIn
    {
        public In(IBlueprint parent,
                  string displayName,
                  string objectType)
            : base(parent, displayName, objectType)
        {
            ConstantValue = "null";
        }

        public In(IBlueprint parent, string objectType)
            : base(parent, objectType)
        {
            ConstantValue = "null";
        }

        public IOut? Previous { get; set; }
    }

    public class Out : Object, IOut
    {
        public Out(IBlueprint parent,
                   string displayName,
                   string objectType)
            : base(parent, displayName, objectType)
        {
            ConstantValue = "null";
        }

        public Out(IBlueprint parent, string objectType)
            : base(parent, objectType)
        {
            ConstantValue = "null";
        }
    }
}
