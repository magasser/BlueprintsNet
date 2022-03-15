
namespace BlueprintsNet.Core.Models.Blueprints;

public class Connection : NodeBase
{
    private Connection(string displayName) : base(displayName) { }

    private Connection() { }

    public class In : Connection
    {
        public In(string displayName) : base(displayName) { }

        public In() { }
    }

    public class Out : Connection
    {
        public Out(string displayName) : base(displayName) { }

        public Out() { }

        public In? Next { get; set; }
    }
}
