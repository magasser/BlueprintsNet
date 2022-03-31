
namespace BlueprintsNet.Core.Models.Blueprints;

public class Bool : ValueBase
{
    private Bool(IBlueprint parent, string displayName)
        : base(parent, displayName)
    {
        DataType = NodeType.Bool;
    }

    private Bool(IBlueprint parent)
        : base(parent)
    {
        DataType = NodeType.Bool;
    }

    public override NodeType DataType { get; init; }

    public class In : Bool, IIn
    {
        public In(IBlueprint parent, string displayName)
            : base(parent, displayName)
        {
            ConstantValue = "true";
        }

        public In(IBlueprint parent)
            : base(parent)
        {
            ConstantValue = "true";
        }

        public IOut? Previous { get; set; }
    }

    public class Out : Bool, IOut
    {
        public Out(IBlueprint parent, string displayName)
            : base(parent, displayName)
        {
            ConstantValue = "true";
        }

        public Out(IBlueprint parent)
            : base(parent)
        {
            ConstantValue = "true";
        }
    }
}