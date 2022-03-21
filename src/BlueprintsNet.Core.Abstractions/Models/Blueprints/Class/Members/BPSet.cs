
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPSet : BPBase, IBPFlow
{
    public BPSet(IInValue inValue)
    {
        InValue = inValue.MustNotBeNull();

        In = new Connection.In();
        Out = new Connection.Out();

        DisplayName = BPNames.Set;
    }

    public override string DisplayName { get; init; }

    public Connection.In In { get; init; }

    public Connection.Out Out { get; init; }

    public IInValue InValue { get; init; }
}
