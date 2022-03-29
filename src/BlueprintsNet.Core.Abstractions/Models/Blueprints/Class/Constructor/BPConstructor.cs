
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPConstructor : BPBase, IBPFlow
{
    internal BPConstructor(Constructor constructor)
    {
        Constructor = constructor.MustNotBeNull();

        Parameters = Constructor.Parameters
                                .Select(parameter => parameter.ToIn(this))
                                .ToList();

        OutValue = new Object.Out(this, Constructor.ClassName);

        DisplayName = Constructor.ClassName;

        In = new Connection.In(this);
        Out = new Connection.Out(this);
    }

    public override string DisplayName { get; init; }

    public Connection.In In { get; init; }

    public Connection.Out Out { get; init; }

    public bool HasParameters => !Parameters.IsNullOrEmpty();

    public List<IIn> Parameters { get; init; }

    public IOut OutValue { get; init; }

    public Constructor Constructor { get; init; }
}
