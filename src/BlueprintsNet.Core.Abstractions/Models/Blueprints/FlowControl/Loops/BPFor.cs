
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPFor : BPFlowControlBase
{
    public BPFor()
    {
        OutBody = new Connection.Out(this, NodeNames.Body);
        OutCompleted = new Connection.Out(this, NodeNames.Completed);

        StartIndex = new Integer.In(this, NodeNames.StartIndex);
        StopIndex = new Integer.In(this, NodeNames.StopIndex);
        Index = new Integer.Out(this, NodeNames.Index);

        DisplayName = BPNames.For;
        Out = OutCompleted;
    }

    public override string DisplayName { get; init; }

    public Integer.In StartIndex { get; init; }

    public Integer.In StopIndex { get; init; }

    public Integer.Out Index { get; init; }

    public override Connection.Out Out { get; init; }

    public Connection.Out OutBody { get; init; }

    public Connection.Out OutCompleted { get; init; }
}
