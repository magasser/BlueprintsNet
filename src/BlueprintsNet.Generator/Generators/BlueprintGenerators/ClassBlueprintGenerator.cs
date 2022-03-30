
namespace BlueprintsNet.Generator.Generators;

internal partial class BlueprintGenerator : BlueprintGeneratorBase
{
    public override string Generate(BPSet bp)
    {
        bp.MustNotBeNull();

        if (IsGenerated(bp, out var generatedValue))
        {
            return generatedValue!;
        }

        var value = bp.Field.Name;

        var newValue = bp.InValue
                         .Evaluate(this);

        _builder.Append($"{value} = {newValue};")
                .NewLine();

        var result = _builder.ToString();

        AddGenerated(bp, result);

        _builder.Clear();

        return result;
    }

    public override string Generate(BPGet bp)
    {
        bp.MustNotBeNull();

        if (IsGenerated(bp, out var generatedValue))
        {
            return generatedValue!;
        }

        var result = bp.Field.Name;

        AddGenerated(bp, result);

        return result;
    }

    public override string Generate(BPMethod bp)
    {
        bp.MustNotBeNull();

        if (IsGenerated(bp, out var generatedValue))
        {
            return generatedValue!;
        }

        _builder.Append($"{bp.Method.Name}(");

        if (bp.Parameters is not null)
        {
            bp.Parameters
              .ToList()
              .ForEach(value =>
              {
                  var gen = value.Evaluate(this);

                  _builder.Append($"{gen}, ");
              });

            _builder.Remove(_builder.Length - 2, length: 2);
        }

        _builder.Append(");")
                .NewLine();

        var result = _builder.ToString();

        AddGenerated(bp, result);

        _builder.Clear();

        return result;
    }

    public override string Generate(BPMethodIn bp)
    {
        bp.MustNotBeNull();

        if (IsGenerated(bp, out var generatedValue))
        {
            return generatedValue!;
        }

        var body = bp.Out
                     .Evaluate(this);

        var accessModifier = bp.Method.AccessModifier
                                      .ToString()
                                      .ToLower();

        _builder.Append($"{accessModifier} {bp.Method.Name}(");


        if (bp.Method.Parameters.Count != 0)
        {
            bp.Method.Parameters
                     .ToList()
                     .ForEach(value =>
                     {
                         var parameterType = value is ObjectParameter objectParameter
                             ? objectParameter.ObjectType
                             : value.NodeType
                                    .GetBuiltInType();
                         _builder.Append($"{parameterType} {value.Name}, ");
                     });

            _builder.Remove(_builder.Length - 2, length: 2);
        }

        _builder.Append(")")
                .NewLine()
                .Append('{')
                .NewLine()
                .Append(body.IndentLines(indentLevel: 1))
                .NewLine()
                .Append('}')
                .NewLine();

        var result = _builder.ToString();

        AddGenerated(bp, result);

        _builder.Clear();

        return result;
    }

    public override string Generate(BPConstructorIn bp)
    {
        bp.MustNotBeNull();

        if (IsGenerated(bp, out var generatedValue))
        {
            return generatedValue!;
        }

        var body = bp.Out
                     .Evaluate(this);

        var accessModifier = bp.Constructor.AccessModifier
                                           .ToString()
                                           .ToLower();

        _builder.Append($"{accessModifier} (");


        if (bp.Constructor.Parameters.Count != 0)
        {
            bp.Constructor.Parameters
                          .ToList()
                          .ForEach(value => _builder.Append($"{value.Name}, "));

            _builder.Remove(_builder.Length - 2, length: 2);
        }

        _builder.Append(')')
                .NewLine()
                .Append('{')
                .NewLine()
                .Append(body.IndentLines(indentLevel: 1))
                .NewLine()
                .Append('}')
                .NewLine();

        var result = _builder.ToString();

        AddGenerated(bp, result);

        _builder.Clear();

        return result;
    }

    public override string Generate(BPConstructor bp)
    {
        bp.MustNotBeNull();

        if (IsGenerated(bp, out var generatedValue))
        {
            return generatedValue!;
        }

        _builder.Append($"new {bp.Constructor.ClassName}(");

        if (bp.Parameters is not null)
        {
            bp.Parameters
              .ToList()
              .ForEach(value =>
              {
                  var gen = value.Evaluate(this);

                  _builder.Append($"{gen}, ");
              });

            _builder.Remove(_builder.Length - 2, length: 2);
        }

        _builder.Append(')')
                .NewLine();

        var result = _builder.ToString();

        AddGenerated(bp, result);

        _builder.Clear();

        return result;
    }

    public override string Generate(BPReturn bp)
    {
        bp.MustNotBeNull();

        if (IsGenerated(bp, out var generatedValue))
        {
            return generatedValue!;
        }

        _builder.Append("return");

        if (bp.HasReturnValue)
        {
            var value = bp.ReturnValue!.Evaluate(this);

            _builder.Append($" {value}");
        }

        _builder.Append(';');

        var result = _builder.ToString();

        AddGenerated(bp, result);

        _builder.Clear();

        return result;
    }
}
