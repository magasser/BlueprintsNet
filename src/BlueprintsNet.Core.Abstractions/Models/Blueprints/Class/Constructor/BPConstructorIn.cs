
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPConstructorIn : BPBase
{
    private BPConstructorIn() { }

    public BPConstructorIn(Constructor constructor,
        List<IOutValue> inValues)
    {
        Constructor = constructor.MustNotBeNull();
        InValues = inValues.MustNotBeNull();

        DisplayName = Constructor.ClassName;

        Out = new Connection.Out(this);
    }

    public BPConstructorIn(Constructor constructor) : this(constructor, new List<IOutValue>()) { }

    public override string DisplayName { get; init; }

    public Connection.Out Out { get; init; }

    public bool HasInValues => !InValues.IsNullOrEmpty();

    public List<IOutValue> InValues { get; init; }

    public Constructor Constructor { get; init; }
}
