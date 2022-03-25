
namespace BlueprintsNet.Core.Models.Classes;

public class Constructor
{
    private readonly List<Parameter> _parameters;

    public Constructor(string className, AccessModifier accessModifier)
    {
        ClassName = className.MustNotBeNullOrWhiteSpace();
        AccessModifier = accessModifier.MustBeValidEnumValue();

        _parameters = new List<Parameter>();

        Start = new BPConstructorIn(ClassName);

        Blueprints = new List<IBlueprint>();
    }

    public string ClassName { get; init; }

    public AccessModifier AccessModifier { get; set; }

    public IReadOnlyList<Parameter> Parameters => _parameters;

    public BPConstructorIn Start { get; init; }

    public List<IBlueprint> Blueprints { get; init; }

    public bool AddParameter(Parameter parameter)
    {
        if (_parameters.Contains(parameter))
        {
            return false;
        }

        _parameters.Add(parameter);

        Start.InValues
            .Add(parameter.GetInValue(Start));

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
