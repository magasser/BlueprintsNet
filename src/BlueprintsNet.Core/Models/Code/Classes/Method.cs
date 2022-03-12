
namespace BlueprintsNet.Core.Models;

public class Method : IMethod
{
    public Method(string name, AccessModifier accessModifier)
    {
        Name = name.MustNotBeNullOrWhiteSpace();
        AccessModifier = accessModifier.MustBeValidEnumValue();

        Parameters = new List<Parameter>();
        Statements = new List<IStatement>();
    }

    public string Name { get; set; }

    public AccessModifier AccessModifier { get; set; }

    public List<Parameter> Parameters { get; }

    public Return? ReturnValue { get; set; }

    public List<IStatement> Statements { get; }
}
