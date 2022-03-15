using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlueprintsNet.Core.Models.Blueprints;

internal class BPMethod : BPBase
{
    public BPMethod(string displayName,
                    IReadOnlyList<IInValue>? inValues,
                    IOutValue? outValue)
    {
        DisplayName = displayName.MustNotBeNullOrWhiteSpace();
        InValues = inValues;
        OutValue = outValue;

        In = new Connection.In();
        Out = new Connection.Out();
    }

    public BPMethod(string displayName, IReadOnlyList<IInValue>? inValues) : this(displayName, inValues, null) { }

    public BPMethod(string displayName) : this(displayName, null) { }

    public override string DisplayName { get; }

    public Connection.In In { get; }

    public Connection.Out Out { get; }

    public bool HasInValues => !InValues.IsNullOrEmpty();

    public IReadOnlyList<IInValue>? InValues { get; }

    public bool HasOutValue => OutValue is not null;

    public IOutValue? OutValue { get; }
}
