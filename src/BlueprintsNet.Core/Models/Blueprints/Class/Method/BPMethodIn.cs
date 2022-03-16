
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPMethodIn : BPBase
{
    public BPMethodIn(string displayName,
        List<IInValue> inValues)
    {
        DisplayName = displayName.MustNotBeNullOrWhiteSpace();
        InValues = inValues;

        Out = new Connection.Out();
    }

    public BPMethodIn(string displayName) : this(displayName, new List<IInValue>()) { }

    public override string DisplayName { get; }

    public Connection.Out Out { get; }

    public bool HasInValues => !InValues.IsNullOrEmpty();

    public List<IInValue> InValues { get; }
}
