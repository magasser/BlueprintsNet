
namespace BlueprintsNet.Core.Models;

public class Setter
{
    public Setter(Value value)
    {
        Value = value.MustNotBeNull();

        Statements = new List<IStatement>();
    }

    public AccessModifier AccessModifier { get; set; }

    public Value Value { get; set; }

    public List<IStatement> Statements { get; }
}

