
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class BPMathBase : BPBase, IBPMath
{
    protected BPMathBase()
    {
        Result = new NumberNode();
    }

    public NumberNode Result { get; }

    public override string DisplayName => throw new NotImplementedException();
}
