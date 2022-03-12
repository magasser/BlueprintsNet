
namespace BlueprintsNet.Core.Models;

public class Value : IValue
{
    protected Value(Type type)
    {
        Type = type.MustNotBeNull();
    }

    public Type Type { get; set; }
}
