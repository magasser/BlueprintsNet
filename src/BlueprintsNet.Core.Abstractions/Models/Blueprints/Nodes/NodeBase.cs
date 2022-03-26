
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class NodeBase : INode
{
    protected NodeBase(IBlueprint parent, string displayName)
    {
        Parent = parent.MustNotBeNull();
        DisplayName = displayName.MustNotBeNull();
    }

    protected NodeBase(IBlueprint parent) : this(parent, string.Empty) { }

    public IBlueprint Parent { get; init; }

    public string DisplayName { get; init; }
}
