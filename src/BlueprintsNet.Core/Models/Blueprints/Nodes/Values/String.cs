using System;
using System.Linq;

namespace BlueprintsNet.Core.Models.Blueprints;

public class String : NodeBase
{
    private String(string displayName) : base(displayName) { }

    private String() { }

    public class In : String
    {
        internal In(string displayName) : base(displayName) { }

        internal In() { }
    }

    public class Out : String
    {
        internal Out(string displayName) : base(displayName) { }

        internal Out() { }
    }
}
