
namespace BlueprintsNet.Core.Models.Blueprints;

public class Integer : ValueBase
{
    private Integer(string displayName)
        : base(displayName)
    {
        DataType = DataType.Integer;
    }

    private Integer()
    {
        DataType = DataType.Integer;
    }

    public override DataType DataType { get; init; }

    public class In : Integer, IInValue
    {
        public In(string displayName) : base(displayName) { }

        public In() { }
    }

    public class Out : Integer, IOutValue
    {
        public Out(string displayName) : base(displayName) { }

        public Out() { }
    }
}
