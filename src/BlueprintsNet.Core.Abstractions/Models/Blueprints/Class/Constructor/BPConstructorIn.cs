
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPConstructorIn : BPBase
{
    private BPConstructorIn() { }

    public BPConstructorIn(string displayName,
        List<IInValue> inValues)
    {
        DisplayName = displayName.MustNotBeNullOrWhiteSpace();
        InValues = inValues;

        Out = new Connection.Out(this);
    }

    public BPConstructorIn(string displayName) : this(displayName, new List<IInValue>()) { }

    public override string DisplayName { get; init; }

    public Connection.Out Out { get; init; }

    public bool HasInValues => !InValues.IsNullOrEmpty();

    public List<IInValue> InValues { get; init; }
}
