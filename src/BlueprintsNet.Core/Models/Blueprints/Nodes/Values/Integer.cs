
namespace BlueprintsNet.Core.Models.Blueprints;

public class Integer : ValueBase
{
    private Integer(string displayName) : base(displayName) { }

    private Integer() { }

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
