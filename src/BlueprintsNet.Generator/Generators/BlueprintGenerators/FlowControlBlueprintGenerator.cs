using System;
using System.Linq;

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

        var condition = bp.Condition.Previous?.Parent.Generate(this) ?? bp.Condition.ConstantValue;

        var ifBody = bp.OutTrue.Next?.Parent.Generate(this) ?? string.Empty;

        _builder.Append("if (")
                .Append(condition)
                .Append(')')
                .NewLine()
                .Append('{')
                .NewLine();

        _builder.Append(ifBody.IndentLines(indentLevel: 1))
                .NewLine()
                .Append('}')
                .NewLine();

        if (bp.OutFalse.HasNext)
        {
            _builder.Append("else")
                    .NewLine()
                    .Append('{')
                    .NewLine();

            var elseBody = bp.OutFalse.Next!.Parent
                                            .Generate(this);

            _builder.Append(elseBody.IndentLines(indentLevel: 1))
                    .NewLine()
                    .Append('}')
                    .NewLine();
        }

        var result = _builder.ToString();

        AddGenerated(bp, result);

        _builder.Clear();

        return result;
    }

    public override string Generate(BPFor bp)
    {
        bp.MustNotBeNull();

        if (IsGenerated(bp, out var generatedValue))
        {
            return generatedValue!;
        }

        var startIndex = bp.StartIndex.Previous?.Parent.Generate(this) ?? bp.StartIndex.ConstantValue;
        var stopIndex = bp.StopIndex.Previous?.Parent.Generate(this) ?? bp.StopIndex.ConstantValue;

        var body = bp.OutBody.Next?.Parent.Generate(this) ?? string.Empty;

        _builder.Append("for (var i = ")
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

        var result = _builder.ToString();

        AddGenerated(bp, result);

        _builder.Clear();

        return result;
    }
}
