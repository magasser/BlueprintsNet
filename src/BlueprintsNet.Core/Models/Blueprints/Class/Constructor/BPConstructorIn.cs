
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPConstructorIn : BPBase
{
    public BPConstructorIn(string displayName,
        List<IInValue> inValues)
    {
        DisplayName = displayName.MustNotBeNullOrWhiteSpace();
        InValues = inValues;

        Out = new Connection.Out();
    }

    public BPConstructorIn(string displayName) : this(displayName, new List<IInValue>()) { }

    public override string DisplayName { get; }

    public Connection.Out Out { get; }

    public bool HasInValues => !InValues.IsNullOrEmpty();

    public List<IInValue> InValues { get; }
}
