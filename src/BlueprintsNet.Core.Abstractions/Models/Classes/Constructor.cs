
namespace BlueprintsNet.Core.Models.Classes;

public class Constructor
{
    private readonly List<Parameter> _parameters;
    private readonly List<BPConstructor> _references;

    public Constructor(string className, AccessModifier accessModifier)
    {
        ClassName = className.MustNotBeNullOrWhiteSpace();
        AccessModifier = accessModifier.MustBeValidEnumValue();

        _parameters = new List<Parameter>();
        _references = new List<BPConstructor>();

        Start = new BPConstructorIn(this);

        Blueprints = new List<IBlueprint>();
    }

    public string ClassName { get; init; }

    public AccessModifier AccessModifier { get; set; }

    public IReadOnlyList<Parameter> Parameters => _parameters;

    public BPConstructorIn Start { get; init; }

    public IReadOnlyList<BPConstructor> References => _references;

    public List<IBlueprint> Blueprints { get; init; }

    public BPConstructor CreateBlueprint()
    {
        var bp = new BPConstructor(this);

        _references.Add(bp);

        return bp;
    }

    public bool DeleteBlueprint(BPConstructor bp)
    {
        return _references.Remove(bp);
    }

    public bool AddParameter(Parameter parameter)
    {
        if (_parameters.Contains(parameter))
        {
            return false;
        }

        _parameters.Add(parameter);

        Start.Parameters
             .Add(parameter.ToOut(Start));

        return true;
    }

    public void RemoveParameter(Parameter parameter)
    {
        _parameters.Remove(parameter);

        Start.Parameters
             .Remove(Start.Parameters
                          .First(value => value.DisplayName == parameter.Name));
    }
}
