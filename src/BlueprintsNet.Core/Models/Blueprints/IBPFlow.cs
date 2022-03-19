
namespace BlueprintsNet.Core.Models.Blueprints;

public interface IBPFlow
{
    Connection.In In { get; init; }

    Connection.Out Out { get; init; }
}
