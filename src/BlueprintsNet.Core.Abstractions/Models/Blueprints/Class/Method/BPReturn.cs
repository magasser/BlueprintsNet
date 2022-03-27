
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPReturn : BPBase
{
    public BPReturn(IInValue? returnValue)
    {
        ReturnValue = returnValue;

        In = new Connection.In(this);

        DisplayName = BPNames.Return;
    }

    public BPReturn() : this(null) { }

    public override string DisplayName { get; init; }

    public Connection.In In { get; init; }

    public bool HasReturnValue => ReturnValue is not null;

    public IInValue? ReturnValue { get; set; }
}
