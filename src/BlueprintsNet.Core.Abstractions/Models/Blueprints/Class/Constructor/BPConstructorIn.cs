
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPConstructorIn : BPBase, IEntryPoint
{
    private BPConstructorIn() { }

    internal BPConstructorIn(Constructor constructor)
    {
        Constructor = constructor.MustNotBeNull();

        Parameters = Constructor.Parameters
                                .Select(parameter => parameter.ToOut(this))
                                .ToList();

        DisplayName = Constructor.ClassName;

        Out = new Connection.Out(this);
    }

    public override string DisplayName { get; init; }

    public Connection.Out Out { get; init; }

    public bool HasParameters => !Parameters.IsNullOrEmpty();

    public List<IOut> Parameters { get; init; }

    public Constructor Constructor { get; init; }
}
