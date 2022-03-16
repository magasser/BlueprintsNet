
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPSet : BPBase, IBPFlow
{
    public BPSet(IInValue inValue)
    {
        InValue = inValue.MustNotBeNull();

        In = new Connection.In();
        Out = new Connection.Out();
    }

    public override string DisplayName => BPNames.Set;

    public Connection.In In { get; }

    public Connection.Out Out { get; }

    public IInValue InValue { get; }
}
