
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPConstructor : BPBase, IBPFlow
{
    public BPConstructor(Constructor constructor,
                         IReadOnlyList<IInValue>? inValues,
                         IOutValue? outValue)
    {
        Constructor = constructor.MustNotBeNull();

        InValues = inValues;
        OutValue = outValue;

        DisplayName = Constructor.ClassName;

        In = new Connection.In(this);
        Out = new Connection.Out(this);
    }

    public BPConstructor(Constructor constructor, IReadOnlyList<IInValue>? inValues)
        : this(constructor, inValues, null) { }

    public BPConstructor(Constructor constructor) : this(constructor, null) { }

    public override string DisplayName { get; init; }

    public Connection.In In { get; init; }

    public Connection.Out Out { get; init; }

    public bool HasInValues => !InValues.IsNullOrEmpty();

    public IReadOnlyList<IInValue>? InValues { get; init; }

    public bool HasOutValue => OutValue is not null;

    public IOutValue? OutValue { get; init; }

    public Constructor Constructor { get; init; }
}
