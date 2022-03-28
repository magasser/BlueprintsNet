
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPSet : BPBase, IBPFlow
{
    public BPSet(Field field, IInValue inValue)
    {
        InValue = inValue.MustNotBeNull();
        Field = field.MustNotBeNull();

        In = new Connection.In(this);
        Out = new Connection.Out(this);

        DisplayName = BPNames.Set;
    }

    public override string DisplayName { get; init; }

    public Connection.In In { get; init; }

    public Connection.Out Out { get; init; }

    public Field Field { get; init; }

    public IInValue InValue { get; init; }
}
