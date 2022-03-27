
namespace BlueprintsNet.Generator.Generators;

internal partial class BlueprintGenerator : BlueprintGeneratorBase
{
    public override string Generate(BPLogicalAnd bp)
    {
        /*var builder = new StringBuilder();

        var in1 = bp.In1.Previous?.Parent.Generate(this) ?? "true";
        var in2 = bp.In2.Previous?.Parent.Generate(this) ?? "true";

        builder.Append("(")
            .Append(in1)
            .Append(" && ")
            .Append(in2);

        bp.AdditionalInputs
            .ForEach(input =>
            {
                var gen = input.Previous?.Parent.Generate(this) ?? true;

                builder.Append(" && ")
                    .Append(gen);
            });

        builder.Append(")");

        return builder.ToString();*/
        throw new NotImplementedException();
    }
}
