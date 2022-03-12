using BlueprintsNet.Core.Models;

namespace BlueprintsNet.Wpf.Blueprints;

public abstract class BlueprintBase : IBlueprint
{
    protected BlueprintBase() : this(new Position { X = 0, Y = 0 }) { }

    protected BlueprintBase(Position position) { Position = position.MustNotBeNull(); }

    public Position Position { get; set; }
}
