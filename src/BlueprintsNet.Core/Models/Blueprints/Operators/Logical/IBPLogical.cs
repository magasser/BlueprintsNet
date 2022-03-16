
namespace BlueprintsNet.Core.Models.Blueprints;

public interface IBPLogical
{
    Bool.In In1 { get; }

    Bool.In In2 { get; }

    List<Bool.In> AdditionalInputs { get; }

    Bool.Out Out { get; }
}
