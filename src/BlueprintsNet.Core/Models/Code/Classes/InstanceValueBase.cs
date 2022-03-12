
namespace BlueprintsNet.Core.Models;

public abstract class InstanceValueBase : Value, IInstanceValue
{
    protected InstanceValueBase(string name,
                                AccessModifier accessModifier,
                                Type type)
        : base(type)
    {
        Name = name.MustNotBeNullOrWhiteSpace();
        AccessModifier = accessModifier.MustBeValidEnumValue();
    }

    public string Name { get; set; }

    public AccessModifier AccessModifier { get; set; }
}
