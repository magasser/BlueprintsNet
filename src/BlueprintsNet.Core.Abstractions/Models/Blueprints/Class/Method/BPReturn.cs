
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPReturn : BPBase
{
    internal BPReturn(Method method)
    {
        Method = method.MustNotBeNull();

        ReturnValue = Method.HasReturnValue
            ? Method is ObjectMethod objectMethod
                ? Method.ReturnNodeType!.Value
                                        .ToIn(this, NodeNames.Result, objectMethod.ObjectType)
                : Method.ReturnNodeType!.Value
                                        .ToIn(this, NodeNames.Result)
            : null;

        In = new Connection.In(this);

        DisplayName = BPNames.Return;
    }

    public override string DisplayName { get; init; }

    public Method Method { get; init; }

    public Connection.In In { get; init; }

    public bool HasReturnValue => ReturnValue is not null;

    public IIn? ReturnValue { get; set; }
}
