
namespace BlueprintsNet.Core.Models;

public abstract class InstanceValueBase<T> : ValueBase<T>, IInstanceValue<T>
{
    protected InstanceValueBase(AccessModifier accessModifier, T value)
        : base(value)
    {
        AccessModifier = accessModifier.MustBeValidEnumValue();
    }

    public AccessModifier AccessModifier { get; set; }
}
