
namespace BlueprintsNet.Core.Models;

public class Parameter : Value
{
    public Parameter(string name, Type type)
        : base(type)
    {
        Name = name.MustNotBeNullOrWhiteSpace();
    }

    public string Name { get; set; }
}
