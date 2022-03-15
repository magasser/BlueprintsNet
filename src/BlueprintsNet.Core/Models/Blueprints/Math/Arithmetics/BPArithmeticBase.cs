
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class BPArithmeticBase : BPMathBase, IBPArithmetic
{
    internal BPArithmeticBase()
    {
        Inputs = new List<Integer.In> { new Integer.In(), new Integer.In() };
    }

    public IList<Integer.In> Inputs { get; }
}
