
namespace BlueprintsNet.Core.Models.Blueprints;

public class Integer : ValueBase
{
    private Integer(IBlueprint parent, string displayName)
        : base(parent, displayName)
    {
        DataType = NodeType.Integer;
    }

    private Integer(IBlueprint parent)
        : base(parent)
    {
        DataType = NodeType.Integer;
    }

    public override NodeType DataType { get; init; }

    public class In : Integer, IIn
    {
        public In(IBlueprint parent, string displayName)
            : base(parent, displayName)
        {
            ConstantValue = "0";
        }

        public In(IBlueprint parent)
            : base(parent)
        {
            ConstantValue = "0";
        }

        public IOut? Previous { get; set; }
    }

    public class Out : Integer, IOut
    {
        public Out(IBlueprint parent, string displayName)
            : base(parent, displayName)
        {
            ConstantValue = "0";
        }

        public Out(IBlueprint parent)
            : base(parent)
        {
            ConstantValue = "0";
        }
    }
}
