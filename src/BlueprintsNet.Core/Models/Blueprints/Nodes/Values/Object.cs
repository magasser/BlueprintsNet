
namespace BlueprintsNet.Core.Models.Blueprints;

public class Object : ValueBase
{
    private Object(string displayName, Type type)
        : base(displayName)
    {
        Type = type.MustNotBeNull();
    }

    private Object(Type type) : this(string.Empty, type) { }

    public override Type Type { get; }

    public class In : Object, IInValue
    {
        public In(string displayName, Type type) : base(displayName, type) { }

        public In(Type type) : base(type) { }
    }

    public class Out : Object, IOutValue
    {
        public Out(string displayName, Type type) : base(displayName, type) { }

        public Out(Type type) : base(type) { }
    }
}
