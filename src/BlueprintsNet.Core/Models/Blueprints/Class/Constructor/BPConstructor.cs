
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPConstructor : BPBase, IBPFlow
{
    public BPConstructor(string displayName,
                         IReadOnlyList<IInValue>? inValues,
                         IOutValue? outValue)
    {
        DisplayName = displayName.MustNotBeNullOrWhiteSpace();
        InValues = inValues;
        OutValue = outValue;

        In = new Connection.In();
        Out = new Connection.Out();
    }

    public BPConstructor(string displayName, IReadOnlyList<IInValue>? inValues) : this(displayName, inValues, null) { }

    public BPConstructor(string displayName) : this(displayName, null) { }

    public override string DisplayName { get; init; }

    public Connection.In In { get; init; }

    public Connection.Out Out { get; init; }

    public bool HasInValues => !InValues.IsNullOrEmpty();

    public IReadOnlyList<IInValue>? InValues { get; init; }

    public bool HasOutValue => OutValue is not null;

    public IOutValue? OutValue { get; init; }
}
