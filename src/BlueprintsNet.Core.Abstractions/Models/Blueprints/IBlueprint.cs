
namespace BlueprintsNet.Core.Models.Blueprints;

public interface IBlueprint
{
    string DisplayName { get; init; }

    Position Position { get; set; }
}
