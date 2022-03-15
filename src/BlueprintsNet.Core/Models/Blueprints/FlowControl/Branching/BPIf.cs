
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPIf : BPFlowControlBase
{
    internal BPIf()
    {
        OutTrue = new Connection.Out(NodeNames.True);
        OutFalse = new Connection.Out(NodeNames.False);
        Condition = new Bool.In(NodeNames.Condition);
    }

    public override string DisplayName => BPNames.If;

    public override Connection Out => OutTrue;

    public Connection OutTrue { get; }

    public Connection OutFalse { get; }

    public Bool Condition { get; }
}
