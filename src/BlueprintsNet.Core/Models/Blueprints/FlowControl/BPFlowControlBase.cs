
namespace BlueprintsNet.Core.Models.Blueprints;

public abstract class BPFlowControlBase : BPBase, IBPFlowControl
{
    protected BPFlowControlBase()
    {
        In = new Connection.In();
    }

    public Connection.In In { get; }

    public abstract Connection.Out Out { get; }
}
