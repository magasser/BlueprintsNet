
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class NodeBase : INode
{
    protected NodeBase(string displayName)
    {
        DisplayName = displayName.MustNotBeNull();
    }

    protected NodeBase() : this(string.Empty) { }

    public string DisplayName { get; init; }
}
