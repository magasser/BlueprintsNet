
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPMethod : BPBase, IBPFlow
{
    public BPMethod(Method method,
                    IReadOnlyList<IInValue>? inValues,
                    IOutValue? outValue)
    {
        Method = method.MustNotBeNull();
        InValues = inValues;
        OutValue = outValue;

        DisplayName = Method.Name;

        In = new Connection.In(this);
        Out = new Connection.Out(this);
    }

    public BPMethod(Method method, IReadOnlyList<IInValue>? inValues) : this(method, inValues, null) { }

    public BPMethod(Method method) : this(method, null) { }

    public override string DisplayName { get; init; }

    public Connection.In In { get; init; }

    public Connection.Out Out { get; init; }

    public bool HasInValues => !InValues.IsNullOrEmpty();

    public IReadOnlyList<IInValue>? InValues { get; init; }

    public bool HasOutValue => OutValue is not null;

    public IOutValue? OutValue { get; init; }

    public Method Method { get; init; }
}
