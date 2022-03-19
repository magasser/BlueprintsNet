
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPMethodIn : BPBase
{
    private BPMethodIn() { }

    public BPMethodIn(string displayName,
        List<IInValue> inValues)
    {
        DisplayName = displayName.MustNotBeNullOrWhiteSpace();
        InValues = inValues;

        Out = new Connection.Out();
    }

    public BPMethodIn(string displayName) : this(displayName, new List<IInValue>()) { }

    public override string DisplayName { get; init; }

    public Connection.Out Out { get; init; }

    public bool HasInValues => !InValues.IsNullOrEmpty();

    public List<IInValue> InValues { get; init; }
}
