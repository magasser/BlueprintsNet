
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPMethodIn : BPBase, IEntryPoint
{
    private BPMethodIn() { }

    public BPMethodIn(Method method)
    {
        Method = method.MustNotBeNull();

        Parameters = Method.Parameters
                           .Select(parameter => parameter.ToOut(this))
                           .ToList();

        DisplayName = Method.Name;
        Out = new Connection.Out(this);
    }

    public override string DisplayName { get; init; }

    public Connection.Out Out { get; init; }

    public bool HasParameters => !Parameters.IsNullOrEmpty();

    public List<IOut> Parameters { get; init; }

    public Method Method { get; init; }
}
