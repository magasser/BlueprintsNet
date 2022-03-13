using BlueprintsNet.Core.Models;

namespace BlueprintsNet.Wpf.Models.Blueprints;

public abstract class BPBase : IBlueprint
{
    protected BPBase() : this(new Position { X = 0, Y = 0 }) { }

    protected BPBase(Position position)
    {
        Position = position.MustNotBeNull();
    }

    public Position Position { get; set; }
}
