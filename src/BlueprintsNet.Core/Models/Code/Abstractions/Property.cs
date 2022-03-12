
namespace BlueprintsNet.Core.Models;

public class Property<T> : InstanceValueBase<T>
{
    public Property(AccessModifier accessModifier, T value)
        : base(accessModifier, value)
    {
    }

    public bool HasSetter => Setter is not null;

    public Method Getter { get; set; }

    public Method? Setter { get; set; }
}
