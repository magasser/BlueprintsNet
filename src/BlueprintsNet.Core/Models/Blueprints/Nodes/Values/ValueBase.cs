namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class ValueBase : NodeBase, IValue
{
    protected ValueBase(string displayName) : base(displayName) { }

    protected ValueBase() { }

    public abstract Type Type { get; }
}
