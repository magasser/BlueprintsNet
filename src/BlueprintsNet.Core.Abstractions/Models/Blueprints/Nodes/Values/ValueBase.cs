
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class ValueBase : NodeBase, IValue
{
    protected ValueBase(IBlueprint parent, string displayName) : base(parent, displayName) { }

    protected ValueBase(IBlueprint parent) : base(parent) { }

    public abstract NodeType DataType { get; init; }

    public string ConstantValue { get; set; }
}
