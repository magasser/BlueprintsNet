
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class BPArithmeticBase : BPMathBase, IBPArithmetic
{
    internal BPArithmeticBase()
    {
        Inputs = new List<NumberNode> { new NumberNode(), new NumberNode() };
    }

    public IList<NumberNode> Inputs { get; }
}
