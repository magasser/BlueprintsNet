﻿
namespace BlueprintsNet.Core.Models.Blueprints;

public class Bool : ValueBase
{
    private Bool(IBlueprint parent, string displayName)
        : base(parent, displayName)
    {
        DataType = DataType.Bool;
    }

    private Bool(IBlueprint parent)
        : base(parent)
    {
        DataType = DataType.Bool;
    }

    public override DataType DataType { get; init; }

    public class In : Bool, IInValue
    {
        public In(IBlueprint parent, string displayName) : base(parent, displayName) { }

        public In(IBlueprint parent) : base(parent) { }

        public IOutValue? Previous { get; set; }
    }

    public class Out : Bool, IOutValue
    {
        public Out(IBlueprint parent, string displayName) : base(parent, displayName) { }

        public Out(IBlueprint parent) : base(parent) { }
    }
}