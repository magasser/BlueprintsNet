
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class NodeBase : INode
{
    internal NodeBase(string displayName)
    {
        DisplayName = displayName.MustNotBeNullOrWhiteSpace();
    }

    internal NodeBase() : this(string.Empty) { }

    public string DisplayName { get; }
}
