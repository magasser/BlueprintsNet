﻿
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPMethodIn : BPBase
{
    private BPMethodIn() { }

    public BPMethodIn(Method method,
        List<IInValue> inValues)
    {
        Method = method.MustNotBeNull();
        InValues = inValues.MustNotBeNull();

        DisplayName = Method.Name;
        Out = new Connection.Out(this);
    }

    public BPMethodIn(Method method) : this(method, new List<IInValue>()) { }

    public override string DisplayName { get; init; }

    public Connection.Out Out { get; init; }

    public bool HasInValues => !InValues.IsNullOrEmpty();

    public List<IInValue> InValues { get; init; }

    public Method Method { get; init; }
}
