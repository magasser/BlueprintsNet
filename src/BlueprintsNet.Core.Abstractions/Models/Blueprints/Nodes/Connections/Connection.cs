
namespace BlueprintsNet.Core.Models.Blueprints;

public class Connection : NodeBase
{
    private Connection(IBlueprint parent, string displayName) : base(parent, displayName) { }

    private Connection(IBlueprint parent) : base(parent) { }

    public class In : Connection
    {
        public In(IBlueprint parent, string displayName) : base(parent, displayName) { }

        public In(IBlueprint parent) : base(parent) { }
    }

    public class Out : Connection
    {
        public Out(IBlueprint parent, string displayName) : base(parent, displayName) { }

        public Out(IBlueprint parent) : base(parent) { }

        public bool HasNext => Next is not null;

        public In? Next { get; set; }
    }
}
