
namespace BlueprintsNet.Core.Models.Blueprints;

public class Object : ValueBase
{
    private Object(string displayName, string objectType)
        : base(displayName)
    {
        ObjectType = objectType.MustNotBeNullOrWhiteSpace();
    }

    private Object(string objectType) : this(string.Empty, objectType) { }

    public string ObjectType { get; }

    public class In : Object, IInValue
    {
        public In(string displayName, string objectType) : base(displayName, objectType) { }

        public In(string objectType) : base(objectType) { }
    }

    public class Out : Object, IOutValue
    {
        public Out(string displayName, string objectType) : base(displayName, objectType) { }

        public Out(string objectType) : base(objectType) { }
    }
}
