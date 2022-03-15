
namespace BlueprintsNet.Core.Models.Blueprints;

public class Bool : NodeBase
{
    private Bool(string displayName) : base(displayName) { }

    private Bool() { }

    public class In : Bool
    {
        internal In(string displayName) : base(displayName) { }

        internal In() { }
    }

    public class Out : Bool
    {
        internal Out(string displayName) : base(displayName) { }

        internal Out() { }
    }
}