
namespace BlueprintsNet.Core.Models.Blueprints;

public interface IBPArithmetic : IBPMath
{
    Integer.In In1 { get; }

    Integer.In In2 { get; }

    List<Integer.In> AdditionalInputs { get; }
}
