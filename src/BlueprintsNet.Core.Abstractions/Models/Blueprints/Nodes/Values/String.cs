
namespace BlueprintsNet.Core.Models.Blueprints;

public class String : ValueBase
{
    private String(IBlueprint parent, string displayName)
        : base(parent, displayName)
    {
        DataType = NodeType.Bool;
    }

    private String(IBlueprint parent)
        : base(parent)
    {
        DataType = NodeType.Bool;
    }

    public override NodeType DataType { get; init; }

    public class In : String, IIn
    {
        public In(IBlueprint parent, string displayName)
            : base(parent, displayName)
        {
            ConstantValue = "\"\"";
        }

        public In(IBlueprint parent)
            : base(parent)
        {
            ConstantValue = "\"\"";
        }

        public IOut? Previous { get; set; }
    }

    public class Out : String, IOut
    {
        public Out(IBlueprint parent, string displayName)
            : base(parent, displayName)
        {
            ConstantValue = "\"\"";
        }

        public Out(IBlueprint parent)
            : base(parent)
        {
            ConstantValue = "\"\"";
        }
    }
}
