﻿
namespace BlueprintsNet.Core.Models.Blueprints;

public class BPField : BPBase
{
    public BPField(string displayName, IOutValue outValue)
    {
        DisplayName = displayName.MustNotBeNullOrWhiteSpace();
        OutValue = outValue.MustNotBeNull();
    }

    public override string DisplayName { get; init; }

    public IOutValue OutValue { get; init; }
}
