
namespace BlueprintsNet.Core.Models.Blueprints;

public interface IBPLogical
{
    Bool.In In1 { get; init; }

    Bool.In In2 { get; init; }

    List<Bool.In> AdditionalInputs { get; init; }

    Bool.Out Out { get; init; }
}
