
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class BPMathBase : BPBase, IBPMath
{
    protected BPMathBase()
    {
        Out = new Number.Out();
    }

    public Number.Out Out { get; }
}
