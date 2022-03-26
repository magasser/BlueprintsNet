
namespace BlueprintsNet.Core.Models.Blueprints;

public interface INode
{
    IBlueprint Parent { get; init; }

    string DisplayName { get; init; }
}
