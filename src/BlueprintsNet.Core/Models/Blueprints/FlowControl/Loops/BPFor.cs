
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPFor : BPFlowControlBase
{
    public BPFor()
    {
        OutBody = new Connection.Out(NodeNames.Body);
        OutCompleted = new Connection.Out(NodeNames.Completed);
    }

    public override string DisplayName => BPNames.For;

    public override Connection.Out Out => OutBody;

    public Connection.Out OutBody { get; }

    public Connection.Out OutCompleted { get; }
}
