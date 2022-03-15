
namespace BlueprintsNet.Core.Models.Blueprints;

public class Integer : NodeBase
{
    private Integer(string displayName) : base(displayName) { }

    private Integer() { }

    public class In : Integer
    {
        internal In(string displayName) : base(displayName) { }

        internal In() { }
    }

    public class Out : Integer
    {
        internal Out(string displayName) : base(displayName) { }

        internal Out() { }
    }
}
