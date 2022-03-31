
namespace BlueprintsNet.Core.Models.Blueprints;

public interface IEntryPoint
{
    Connection.Out Out { get; }

    bool HasParameters { get; }

    List<IOut> Parameters { get; }
}
