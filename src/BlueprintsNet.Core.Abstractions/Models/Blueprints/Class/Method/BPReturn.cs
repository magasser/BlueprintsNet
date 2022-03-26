
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPReturn : BPBase
{
    public BPReturn(IOutValue? outValue)
    {
        OutValue = outValue;

        In = new Connection.In(this);

        DisplayName = BPNames.Return;
    }

    public BPReturn() : this(null) { }

    public override string DisplayName { get; init; }

    public Connection.In In { get; init; }

    public bool HasOutValue => OutValue is not null;

    public IOutValue? OutValue { get; set; }
}
