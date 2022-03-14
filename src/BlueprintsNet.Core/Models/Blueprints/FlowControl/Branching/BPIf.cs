
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPIf : BPFlowControlBase
{
    internal BPIf()
    {
        OutTrue = new OutNode(NodeNames.True);
        OutFalse = new OutNode(NodeNames.False);
        Condition = new BoolNode(NodeNames.Condition);
    }

    public override string DisplayName => BPNames.If;

    public override OutNode Out => OutTrue;

    public OutNode OutTrue { get; }

    public OutNode OutFalse { get; }

    public BoolNode Condition { get; }
}
