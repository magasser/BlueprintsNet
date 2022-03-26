using BlueprintsNet.Core.Models.Blueprints;

namespace BlueprintsNet.Generator.Generators;

internal partial class BlueprintGenerator : BlueprintGeneratorBase
{
    public override string Generate(BPLogicalAnd bp)
    {
        bp.MustNotBeNull();

        var inValues = new List<IInValue> { bp.In1, bp.In2 };
        inValues.AddRange(bp.AdditionalInputs);

        return AddOperator(@operator: "&&",
                           inValues);
    }
}
