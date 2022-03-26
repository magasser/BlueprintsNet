using BlueprintsNet.Core.Models.Blueprints;

namespace BlueprintsNet.Generator.Generators.BlueprintGenerators;

internal partial class BlueprintGenerator : BlueprintGeneratorBase
{
    public override string Generate(BPPlus bp)
    {
        bp.MustNotBeNull();

        var inValues = new List<IInValue> { bp.In1, bp.In2 };
        inValues.AddRange(bp.AdditionalInputs);

        return AddOperator(@operator: "+",
                           inValues);
    }
}
