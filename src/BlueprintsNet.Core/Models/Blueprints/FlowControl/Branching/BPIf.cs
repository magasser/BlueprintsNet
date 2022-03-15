
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPIf : BPFlowControlBase
{
    public BPIf()
    {
        OutTrue = new Connection.Out(NodeNames.True);
        OutFalse = new Connection.Out(NodeNames.False);
        Condition = new Bool.In(NodeNames.Condition);

        List<INode> t = new List<INode>();

        t.Add(new Bool.Out());
    }

    public override string DisplayName => BPNames.If;

    public override Connection.Out Out => OutTrue;

    public Connection.Out OutTrue { get; }

    public Connection.Out OutFalse { get; }

    public Bool Condition { get; }
}
