
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class BPMathBase : BPBase, IBPMath
{
    protected BPMathBase()
    {
        Out = new Integer.Out(this);
    }

    public Integer.Out Out { get; init; }
}
