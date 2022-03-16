
namespace BlueprintsNet.Core.Models.Blueprints;

public class String : ValueBase
{
    private String(string displayName) : base(displayName) { }

    private String() { }

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
