
namespace BlueprintsNet.Core.Models.Blueprints;

public class Object : ValueBase
{
    private Object() { }

    private Object(string displayName, string objectType)
        : base(displayName)
    {
        ObjectType = objectType.MustNotBeNullOrWhiteSpace();
        DataType = DataType.Object;
    }

    private Object(string objectType)
        : this(string.Empty, objectType)
    {
        DataType = DataType.Object;
    }

    public string ObjectType { get; init; }

    public override DataType DataType { get; init; }

    public class In : Object, IInValue
    {
        private In() { }

        public In(string displayName, string objectType) : base(displayName, objectType) { }

        public In(string objectType) : base(objectType) { }
    }

    public class Out : Object, IOutValue
    {
        private Out() { }

        public Out(string displayName, string objectType) : base(displayName, objectType) { }

        public Out(string objectType) : base(objectType) { }
    }
}
