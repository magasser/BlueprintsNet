
namespace BlueprintsNet.Core.Models.Blueprints;

public class Object : ValueBase
{
    private Object(IBlueprint parent,
                   string displayName,
                   string objectType)
        : base(parent, displayName)
    {
        ObjectType = objectType.MustNotBeNullOrWhiteSpace();
        DataType = DataType.Object;
    }

    private Object(IBlueprint parent, string objectType)
        : this(parent, string.Empty, objectType)
    {
        DataType = DataType.Object;
    }

    public string ObjectType { get; init; }

    public override DataType DataType { get; init; }

    public class In : Object, IInValue
    {
        public In(IBlueprint parent,
                  string displayName,
                  string objectType)
            : base(parent, displayName, objectType) { }

        public In(IBlueprint parent, string objectType) : base(parent, objectType) { }

        public IOutValue? Previous { get; set; }
    }

    public class Out : Object, IOutValue
    {
        public Out(IBlueprint parent,
                   string displayName,
                   string objectType)
            : base(parent, displayName, objectType) { }

        public Out(IBlueprint parent, string objectType) : base(parent, objectType) { }
    }
}
