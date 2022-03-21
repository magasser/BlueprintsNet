
namespace BlueprintsNet.Core.Models.Blueprints;

public class String : ValueBase
{
    private String(string displayName)
        : base(displayName)
    {
        DataType = DataType.String;
    }

    private String()
    {
        DataType = DataType.String;
    }

    public override DataType DataType { get; init; }

    public class In : String, IInValue
    {
        public In(string displayName) : base(displayName) { }

        public In() { }
    }

    public class Out : String, IOutValue
    {
        public Out(string displayName) : base(displayName) { }

        public Out() { }
    }
}
