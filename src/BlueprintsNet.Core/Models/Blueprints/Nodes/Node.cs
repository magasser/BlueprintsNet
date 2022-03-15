
namespace BlueprintsNet.Core.Models.Blueprints;

public class Node : NodeBase
{
    private Node(string displayName) : base(displayName) { }

    private Node() { }

    public class In : Node
    {
        public In(string displayName) : base(displayName) { }

        public In() { }
    }

    public class Out : Node
    {
        public Out(string displayName) : base(displayName) { }

        public Out() { }
    }
}
