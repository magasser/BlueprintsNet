
namespace BlueprintsNet.Core.Models.Blueprints;

public class Bool : ValueBase
{
    private Bool(string displayName) : base(displayName) { }

    private Bool() { }

    public override Type Type => typeof(Bool);

    public class In : Bool, IInValue
    {
        internal In(string displayName) : base(displayName) { }

        internal In() { }
    }

    public class Out : Bool, IOutValue
    {
        internal Out(string displayName) : base(displayName) { }

        internal Out() { }
    }
}