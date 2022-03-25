
namespace BlueprintsNet.Core.Models.Blueprints;

public class Integer : ValueBase
{
    private Integer(IBlueprint parent, string displayName)
        : base(parent, displayName)
    {
        DataType = DataType.Bool;
    }

    private Integer(IBlueprint parent)
        : base(parent)
    {
        DataType = DataType.Bool;
    }

    public override DataType DataType { get; init; }

    public class In : Integer, IInValue
    {
        public In(IBlueprint parent, string displayName) : base(parent, displayName) { }

        public In(IBlueprint parent) : base(parent) { }

        public IOutValue? Previous { get; set; }
    }

    public class Out : Integer, IOutValue
    {
        public Out(IBlueprint parent, string displayName) : base(parent, displayName) { }

        public Out(IBlueprint parent) : base(parent) { }
    }
}
