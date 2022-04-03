
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPMethod : BPBase
{
    public BPMethod(Method method)
    {
        Method = method.MustNotBeNull();

        Parameters = Method.Parameters
                           .Select(parameter => parameter.ToIn(this))
                           .ToList();

        OutValue = Method.HasReturnValue
            ? Method is ObjectMethod objectMethod
                ? Method.ReturnNodeType!.Value
                                        .ToOut(this, NodeNames.Result, objectMethod.ObjectType)
                : Method.ReturnNodeType!.Value
                                        .ToOut(this, NodeNames.Result)
            : null;

        DisplayName = Method.Name;
    }

    public override string DisplayName { get; init; }

    public bool HasParameters => !Parameters.IsNullOrEmpty();

    public List<IIn> Parameters { get; init; }

    public bool HasOutValue => OutValue is not null;

    public IOut? OutValue { get; init; }

    public Method Method { get; init; }
}
