
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class BPFlowControlBase : BPBase, IBPFlowControl
{
    internal BPFlowControlBase()
    {
        In = new InNode();
    }

    public InNode In { get; }

    public abstract OutNode Out { get; }
}
