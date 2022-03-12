
namespace BlueprintsNet.Core.Models;

public class Property : InstanceValueBase
{
    public Property(string name,
                    AccessModifier accessModifier,
                    Type type)
        : base(name,
               accessModifier,
               type)
    {
    }

    public bool HasSetter => Setter is not null;

    public Method Getter { get; set; }

    public Method? Setter { get; set; }
}
