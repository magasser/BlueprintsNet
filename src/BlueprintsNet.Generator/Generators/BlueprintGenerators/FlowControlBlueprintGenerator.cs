using System;
using System.Linq;

namespace BlueprintsNet.Generator.Generators;

internal partial class BlueprintGenerator : BlueprintGeneratorBase
{
    public override string Generate(BPIf bp)
    {
        bp.MustNotBeNull();

        var builder = new StringBuilder();

        var condition = bp.Condition.Previous?.Parent.Generate(this) ?? bp.Condition.ConstantValue;

        var ifBody = bp.OutTrue.Next?.Parent.Generate(this) ?? string.Empty;

        builder.Append("if (")
               .Append(condition)
               .Append(')')
               .NewLine()
               .Append('{')
               .NewLine();

        builder.Append(ifBody.IndentLines(indentLevel: 1))
               .NewLine()
               .Append('}')
               .NewLine();

        var next = bp.OutFalse.Next;

        if (next is not null)
        {
            builder.Append("else")
                   .NewLine()
                   .Append('{')
                   .NewLine();

            var elseBody = next.Parent
                               .Generate(this);

            builder.Append(ifBody.IndentLines(indentLevel: 1))
                   .NewLine()
                   .Append('}')
                   .NewLine();
        }

        return builder.ToString();
    }

    public override string Generate(BPFor bp)
    {
        bp.MustNotBeNull();

        var builder = new StringBuilder();

        var startIndex = bp.StartIndex.Previous?.Parent.Generate(this) ?? bp.StartIndex.ConstantValue;
        var stopIndex = bp.StopIndex.Previous?.Parent.Generate(this) ?? bp.StopIndex.ConstantValue;

        var body = bp.OutBody.Next?.Parent.Generate(this) ?? string.Empty;

        builder.Append("for (var i = ")
               .Append(startIndex)
               .Append("; i <= ")
               .Append(stopIndex)
               .Append("; i++)")
               .NewLine()
               .Append('{')
               .NewLine()
               .Append(body.IndentLines(indentLevel: 1))
               .NewLine()
               .Append('}');
    }
}
