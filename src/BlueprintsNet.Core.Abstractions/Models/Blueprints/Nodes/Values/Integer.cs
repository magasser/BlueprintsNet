
namespace BlueprintsNet.Core.Models.Blueprints;

public class Integer : ValueBase
{
    private Integer(IBlueprint parent, string displayName)
        : base(parent, displayName)
    {
        DataType = DataType.Integer;
    }

    private Integer(IBlueprint parent)
        : base(parent)
    {
        DataType = DataType.Integer;
    }

    public override DataType DataType { get; init; }

    public class In : Integer, IInValue
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

        public IOutValue? Previous { get; set; }
    }

    public class Out : Integer, IOutValue
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
