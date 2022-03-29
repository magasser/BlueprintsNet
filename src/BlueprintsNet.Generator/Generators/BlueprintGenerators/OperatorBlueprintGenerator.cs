
namespace BlueprintsNet.Generator.Generators;

internal partial class BlueprintGenerator : BlueprintGeneratorBase
{
    public override string Generate(BPLogicalAnd bp)
    {
        bp.MustNotBeNull();

        if (IsGenerated(bp, out var generatedValue))
        {
            return generatedValue!;
        }

        var inValues = new List<IIn> { bp.In1, bp.In2 };
        inValues.AddRange(bp.AdditionalInputs);

        var result = AddOperator(@operator: "&&",
                           inValues);

        AddGenerated(bp, result);

        _builder.Clear();

        return result;
    }
}
