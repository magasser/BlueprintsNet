
namespace BlueprintsNet.Core.Models.Blueprints;

public interface IBPArithmetic : IBPMath
{
    Integer.In In1 { get; init; }

    Integer.In In2 { get; init; }

    List<Integer.In> AdditionalInputs { get; init; }
}
