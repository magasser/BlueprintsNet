
namespace BlueprintsNet.Core.Models.Blueprints;

public class Integer : ValueBase
{
    private Integer(string displayName) : base(displayName) { }

    private Integer() { }

    public override Type Type => typeof(Integer);

    public class In : Integer, IInValue
    {
        internal In(string displayName) : base(displayName) { }

        internal In() { }
    }

    public class Out : Integer, IOutValue
    {
        public Out(string displayName) : base(displayName) { }

        public Out() { }
    }
}
