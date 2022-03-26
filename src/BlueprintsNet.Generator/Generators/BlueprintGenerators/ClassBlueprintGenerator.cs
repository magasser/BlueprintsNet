
namespace BlueprintsNet.Generator.Generators;

internal partial class BlueprintGenerator : BlueprintGeneratorBase
{
    public override string Generate(BPSet bp)
    {
        bp.MustNotBeNull();

        _builder.Clear();

        var value = bp.Field.Name;
        var newValue = bp.InValue.Previous?.Parent.Generate(this) ?? bp.InValue.ConstantValue;

        _builder.Append(value)
                .Space()
                .Equal()
                .Space()
                .Append(newValue)
                .Semicolon()
                .NewLine();

        return _builder.ToString();
    }

    public override string Generate(BPField bp)
    {
        bp.MustNotBeNull();

        return bp.Field.Name;
    }

    public override string Generate(BPMethod bp)
    {
        bp.MustNotBeNull();

        _builder.Clear();

        _builder.Append(bp.Method.Name)
                .OpenBracket();

        if (bp.InValues is not null)
        {
            bp.InValues
              .ToList()
              .ForEach(value =>
              {
                  var gen = value.Previous?.Parent.Generate(this) ?? value.ConstantValue;

                  _builder.Append(gen)
                          .Comma()
                          .Space();
              });

            _builder.Remove(_builder.Length - 2, length: 2);
        }

        _builder.CloseBracket()
                .Semicolon()
                .NewLine();

        return _builder.ToString();
    }

    public override string Generate(BPMethodIn bp)
    {
        bp.MustNotBeNull();

        _builder.Clear();

        var body = bp.Out.Parent
                         .Generate(this);

        _builder.Append(bp.Method.AccessModifier
                                 .ToString()
                                 .ToLower())
                .Space()
                .OpenBracket();


        if (bp.Method.Parameters.Count != 0)
        {
            bp.Method.Parameters
                     .ToList()
                     .ForEach(value => _builder.Append(value.Name)
                                               .Comma()
                                               .Space());

            _builder.Remove(_builder.Length - 2, length: 2);
        }

        _builder.CloseBracket()
                .NewLine()
                .OpenCurlyBracket()
                .Append(body.IndentLines(indentLevel: 1))
                .NewLine()
                .CloseCurlyBracket()
                .NewLine();

        return _builder.ToString();
    }

    public override string Generate(BPConstructorIn bp)
    {
        bp.MustNotBeNull();

        _builder.Clear();

        var body = bp.Out.Parent
                         .Generate(this);

        _builder.Append(bp.Constructor.AccessModifier
                                      .ToString()
                                      .ToLower())
                .Space()
                .OpenBracket();


        if (bp.Constructor.Parameters.Count != 0)
        {
            bp.Constructor.Parameters
                          .ToList()
                          .ForEach(value => _builder.Append(value.Name)
                                                    .Comma()
                                                    .Space());

            _builder.Remove(_builder.Length - 2, length: 2);
        }

        _builder.CloseBracket()
                .NewLine()
                .OpenCurlyBracket()
                .Append(body.IndentLines(indentLevel: 1))
                .NewLine()
                .CloseCurlyBracket()
                .NewLine();

        return _builder.ToString();
    }

    public override string Generate(BPConstructor bp)
    {
        bp.MustNotBeNull();

        _builder.Clear();

        _builder.Append("new")
                .Space()
                .Append(bp.Constructor.ClassName)
                .OpenBracket();

        if (bp.InValues is not null)
        {
            bp.InValues
              .ToList()
              .ForEach(value =>
              {
                  var gen = value.Previous?.Parent.Generate(this) ?? value.ConstantValue;

                  _builder.Append(gen)
                          .Comma()
                          .Space();
              });

            _builder.Remove(_builder.Length - 2, length: 2);
        }

        _builder.CloseBracket()
                .NewLine();

        return _builder.ToString();
    }

    public override string Generate(BPReturn bp)
    {
        bp.MustNotBeNull();

        _builder.Clear();

        _builder.Append("return");

        if (bp.HasReturnValue)
        {
            var value = bp.ReturnValue!.Previous?.Parent.Generate(this) ?? bp.ReturnValue!.ConstantValue;

            _builder.Space()
                    .Append(value);
        }

        _builder.Semicolon();

        return _builder.ToString();
    }
}
