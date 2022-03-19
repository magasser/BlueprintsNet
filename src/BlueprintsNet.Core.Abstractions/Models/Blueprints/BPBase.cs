
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class BPBase : IBlueprint
{
    protected BPBase() : this(new Position { X = 0, Y = 0 }) { }

    protected BPBase(Position position)
    {
        Position = position.MustNotBeNull();
    }

    public abstract string DisplayName { get; init; }

    public Position Position { get; set; }
}
