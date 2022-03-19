
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPIf : BPFlowControlBase
{
    public BPIf()
    {
        OutTrue = new Connection.Out(NodeNames.True);
        OutFalse = new Connection.Out(NodeNames.False);
        Condition = new Bool.In(NodeNames.Condition);

        DisplayName = BPNames.If;
        Out = OutTrue;
    }

    public override string DisplayName { get; init; }

    public override Connection.Out Out { get; init; }

    public Connection.Out OutTrue { get; init; }

    public Connection.Out OutFalse { get; init; }

    public Bool Condition { get; init; }
}
