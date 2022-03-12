
namespace BlueprintsNet.Core.Models;

public class Getter
{
    public Getter(Return returnValue)
    {
        ReturnValue = returnValue.MustNotBeNull();

        Statements = new List<IStatement>();
    }

    public AccessModifier AccessModifier { get; set; }

    public Return ReturnValue { get; set; }

    public List<IStatement> Statements { get; }
}

