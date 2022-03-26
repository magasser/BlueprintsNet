
namespace BlueprintsNet.Core.Models.Blueprints;

public class String : ValueBase
{
    private String(IBlueprint parent, string displayName)
        : base(parent, displayName)
    {
        DataType = DataType.Bool;
    }

    private String(IBlueprint parent)
        : base(parent)
    {
        DataType = DataType.Bool;
    }

    public override DataType DataType { get; init; }

    public class In : String, IInValue
    {
        public In(IBlueprint parent, string displayName) : base(parent, displayName) { }

        public In(IBlueprint parent) : base(parent) { }

        public IOutValue? Previous { get; set; }
    }

    public class Out : String, IOutValue
    {
        public Out(IBlueprint parent, string displayName) : base(parent, displayName) { }

        public Out(IBlueprint parent) : base(parent) { }
    }
}
