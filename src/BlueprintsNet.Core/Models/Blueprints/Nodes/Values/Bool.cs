
namespace BlueprintsNet.Core.Models.Blueprints;

public class Bool : ValueBase
{
    private Bool(string displayName) : base(displayName) { }

    private Bool() { }

    public class In : Bool, IInValue
    {
        public In(string displayName) : base(displayName) { }

        public In() { }
    }

    public class Out : Bool, IOutValue
    {
        public Out(string displayName) : base(displayName) { }

        public Out() { }
    }
}