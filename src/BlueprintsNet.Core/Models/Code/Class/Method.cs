
namespace BlueprintsNet.Core.Models.Code;

public class Method
{
    private readonly List<Parameter> _parameters;

    public Method(string name, AccessModifier accessModifier)
    {
        Name = name.MustNotBeNullOrWhiteSpace();
        AccessModifier = accessModifier.MustBeValidEnumValue();

        _parameters = new List<Parameter>();

        Start = new BPMethodIn(name);
        Return = new BPReturn();

        Blueprints = new List<IBlueprint>();
    }

    public string Name { get; set; }

    public AccessModifier AccessModifier { get; set; }

    public IReadOnlyList<Parameter> Parameters => _parameters;

    public BPMethodIn Start { get; init; }

    public BPReturn Return { get; init; }

    public List<IBlueprint> Blueprints { get; init; }

    public bool AddParameter(Parameter parameter)
    {
        if (_parameters.Contains(parameter))
        {
            return false;
        }

        _parameters.Add(parameter);

        Start.InValues
            .Add(parameter.GetInValue());

        return true;
    }

    public void RemoveParameter(Parameter parameter)
    {
        _parameters.Remove(parameter);

        Start.InValues
            .Remove(Start.InValues
                        .First(value => value.DisplayName == parameter.Name));
    }
}
