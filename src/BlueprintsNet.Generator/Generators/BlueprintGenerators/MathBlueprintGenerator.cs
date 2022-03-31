
namespace BlueprintsNet.Generator.Generators;

internal partial class BlueprintGenerator : BlueprintGeneratorBase
{
    public override string Generate(BPPlus bp)
    {
        bp.MustNotBeNull();

        if (IsGenerated(bp, out var generatedValue))
        {
            return generatedValue!;
        }

        var inValues = new List<IIn> { bp.In1, bp.In2 };
        inValues.AddRange(bp.AdditionalInputs);

        var result = AddOperator(@operator: "+",
                           inValues);

        AddGenerated(bp, result);

        return result;
    }
}
