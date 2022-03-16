
namespace BlueprintsNet.Core.Models.Blueprints;

public interface IBPFlow
{
    Connection.In In { get; }

    Connection.Out Out { get; }
}
