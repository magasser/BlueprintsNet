
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPFor : BPFlowControlBase
{
    public BPFor()
    {
        OutBody = new Connection.Out(this, NodeNames.Body);
        OutCompleted = new Connection.Out(this, NodeNames.Completed);

        DisplayName = BPNames.For;
        Out = OutBody;
    }

    public override string DisplayName { get; init; }

    public override Connection.Out Out { get; init; }

    public Connection.Out OutBody { get; init; }

    public Connection.Out OutCompleted { get; init; }
}
