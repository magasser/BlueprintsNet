
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class BPArithmeticBase : BPMathBase, IBPArithmetic
{
    protected BPArithmeticBase()
    {
        In1 = new Integer.In();
        In2 = new Integer.In();

        AdditionalInputs = new List<Integer.In>();
    }

    public Integer.In In1 { get; }

    public Integer.In In2 { get; }

    public List<Integer.In> AdditionalInputs { get; }
}
