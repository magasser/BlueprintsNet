
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class BPLogicalBase : BPBase, IBPLogical
{
    protected BPLogicalBase()
    {
        In1 = new Bool.In(this);
        In2 = new Bool.In(this);

        AdditionalInputs = new List<Bool.In>();

        Out = new Bool.Out(this);
    }

    public Bool.In In1 { get; init; }

    public Bool.In In2 { get; init; }

    public List<Bool.In> AdditionalInputs { get; init; }

    public Bool.Out Out { get; init; }
}
