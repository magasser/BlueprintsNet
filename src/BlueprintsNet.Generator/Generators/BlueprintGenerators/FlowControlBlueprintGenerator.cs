
namespace BlueprintsNet.Generator.Generators;

internal partial class BlueprintGenerator : BlueprintGeneratorBase
{
    public override string Generate(BPIf bp)
    {
        bp.MustNotBeNull();

        if (IsGenerated(bp, out var generatedValue))
        {
            return generatedValue!;
        }

        var builder = new StringBuilder();

        var condition = bp.Condition
                          .Evaluate(this);

        var ifBody = bp.OutTrue
                       .Evaluate(this);

        builder.Append($"if ({condition})")
               .NewLine()
               .Append('{')
               .NewLine();

        builder.Append(ifBody.IndentLines(indentLevel: 1))
               .NewLine()
               .Append('}')
               .NewLine();

        if (bp.OutFalse.HasNext)
        {
            builder.Append("else")
                   .NewLine()
                   .Append('{')
                   .NewLine();

            var elseBody = bp.OutFalse
                             .Evaluate(this);

            builder.Append(elseBody.IndentLines(indentLevel: 1))
                   .NewLine()
                   .Append('}');
        }

        var result = builder.ToString();

        AddGenerated(bp, result);

        return result;
    }

    public override string Generate(BPFor bp)
    {
        bp.MustNotBeNull();

        if (IsGenerated(bp, out var generatedValue))
        {
            return generatedValue!;
        }

        var builder = new StringBuilder();

        var startIndex = bp.StartIndex
                           .Evaluate(this);
        var stopIndex = bp.StopIndex
                          .Evaluate(this);

        var body = bp.OutBody
                     .Evaluate(this);

        builder.Append($"for (var i = {startIndex}; i <= {stopIndex}; i++)")
               .NewLine()
               .Append('{')
               .NewLine()
               .Append(body.IndentLines(indentLevel: 1))
               .NewLine()
               .Append('}')
               .NewLine();

        var result = builder.ToString();

        AddGenerated(bp, result);

        return result;
    }
}
