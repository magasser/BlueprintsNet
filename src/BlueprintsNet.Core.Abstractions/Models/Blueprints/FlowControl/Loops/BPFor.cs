
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPFor : BPFlowControlBase
{
    public BPFor()
    {
        OutBody = new Connection.Out(NodeNames.Body);
        OutCompleted = new Connection.Out(NodeNames.Completed);

        DisplayName = BPNames.For;
        Out = OutBody;
    }

    public override string DisplayName { get; init; }

    public override Connection.Out Out { get; init; }

    public Connection.Out OutBody { get; init; }

    public Connection.Out OutCompleted { get; init; }
}
