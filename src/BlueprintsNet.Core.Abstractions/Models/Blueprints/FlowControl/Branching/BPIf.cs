
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPIf : BPFlowControlBase
{
    public BPIf()
    {
        OutTrue = new Connection.Out(this, NodeNames.True);
        OutFalse = new Connection.Out(this, NodeNames.False);
        Condition = new Bool.In(this, NodeNames.Condition);

        DisplayName = BPNames.If;
        Out = OutTrue;
    }

    public override string DisplayName { get; init; }

    public override Connection.Out Out { get; init; }

    public Connection.Out OutTrue { get; init; }

    public Connection.Out OutFalse { get; init; }

    public Bool.In Condition { get; init; }
}
