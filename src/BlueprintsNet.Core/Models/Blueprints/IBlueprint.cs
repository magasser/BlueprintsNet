using BlueprintsNet.Core.Models;

namespace BlueprintsNet.Core.Models.Blueprints;

public interface IBlueprint
{
    string DisplayName { get; }

    Position Position { get; set; }
}
