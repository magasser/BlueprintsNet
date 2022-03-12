
namespace BlueprintsNet.Core.Models;

public class Constructor
{
    public Constructor(AccessModifier accessModifier, Return instance)
    {
        AccessModifier = accessModifier.MustBeValidEnumValue();
        Instance = instance.MustNotBeNull();

        Parameters = new List<Parameter>();
        Statements = new List<IStatement>();
    }

    public AccessModifier AccessModifier { get; set; }

    public List<Parameter> Parameters { get; }

    public Return Instance { get; set; }

    public List<IStatement> Statements { get; }
}
