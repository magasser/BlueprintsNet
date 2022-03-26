
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPMethod : BPBase, IBPFlow
{
    public BPMethod(string displayName,
                    IReadOnlyList<IInValue>? inValues,
                    IOutValue? outValue)
    {
        DisplayName = displayName.MustNotBeNullOrWhiteSpace();
        InValues = inValues;
        OutValue = outValue;

        In = new Connection.In(this);
        Out = new Connection.Out(this);
    }

    public BPMethod(string displayName, IReadOnlyList<IInValue>? inValues) : this(displayName, inValues, null) { }

    public BPMethod(string displayName) : this(displayName, null) { }

    public override string DisplayName { get; init; }

    public Connection.In In { get; init; }

    public Connection.Out Out { get; init; }

    public bool HasInValues => !InValues.IsNullOrEmpty();

    public IReadOnlyList<IInValue>? InValues { get; init; }

    public bool HasOutValue => OutValue is not null;

    public IOutValue? OutValue { get; init; }
}
