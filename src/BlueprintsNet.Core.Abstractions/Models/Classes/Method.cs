
namespace BlueprintsNet.Core.Models.Classes;

public class Method
{
    private readonly List<Parameter> _parameters;
    private readonly List<BPMethod> _references;
    private readonly List<BPReturn> _returnReferences;

    public Method(string name,
                  AccessModifier accessModifier,
                  NodeType? returnNodeType = null)
    {
        Name = name.MustNotBeNullOrWhiteSpace();
        AccessModifier = accessModifier.MustBeValidEnumValue();

        ReturnNodeType = returnNodeType;

        _parameters = new List<Parameter>();
        _references = new List<BPMethod>();
        _returnReferences = new List<BPReturn>();

        Start = new BPMethodIn(this);

        Blueprints = new List<IBlueprint>();
    }

    public string Name { get; set; }

    public bool HasReturnValue => ReturnNodeType.HasValue;

    public NodeType? ReturnNodeType { get; set; }

    public AccessModifier AccessModifier { get; set; }

    public IReadOnlyList<Parameter> Parameters => _parameters;

    public BPMethodIn Start { get; init; }

    public IReadOnlyList<BPMethod> References => _references;

    public IReadOnlyList<BPReturn> ReturnReferences => _returnReferences;

    public BPReturn Return { get; init; }

    public List<IBlueprint> Blueprints { get; init; }

    public BPMethod CreateBlueprint()
    {
        var bp = new BPMethod(this);

        _references.Add(bp);

        return bp;
    }

    public BPReturn CreateReturn()
    {
        var bp = new BPReturn(this);

        _returnReferences.Add(bp);

        return bp;
    }

    public bool DeleteBlueprint(BPMethod bp)
    {
        return _references.Remove(bp);
    }

    public bool DeleteReturn(BPReturn bp)
    {
        return _returnReferences.Remove(bp);
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
