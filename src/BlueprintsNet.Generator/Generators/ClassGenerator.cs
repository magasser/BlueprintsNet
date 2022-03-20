using System.Text;

namespace BlueprintsNet.Generator.Generators;

internal class ClassGenerator : IGenerator<Class>
{
    private readonly ILogger<ClassGenerator> _logger;
    private readonly IGenerator<Constructor> _constrcutorGenerator;
    private readonly IGenerator<Field> _fieldGenerator;
    private readonly IGenerator<Method> _methodGenerator;

    public ClassGenerator(ILogger<ClassGenerator> logger,
                          IGenerator<Constructor> constructorGenerator,
                          IGenerator<Field> fieldGenerator,
                          IGenerator<Method> methodGenerator)
    {
        _logger = logger.MustNotBeNull();
        _constrcutorGenerator = constructorGenerator.MustNotBeNull();
        _fieldGenerator = fieldGenerator.MustNotBeNull();
        _methodGenerator = methodGenerator.MustNotBeNull();
    }

    public string Generate(Class value)
    {
        value.MustNotBeNull();

        _logger.LogTrace("Generate class: {Class}.", value);

        var builder = new StringBuilder();

        var indentLevel = 0;

        value.Usings
            .ForEach(u => builder.AppendLine($"using {u};".Indent(indentLevel)));

        builder.Append(Environment.NewLine);

        builder.Append($"namespace {value.Namespace}{Environment.NewLine}{{{Environment.NewLine}".IndentLines(indentLevel++));

        builder.Append($"{value.AccessModifier.ToString().ToLower()} class {value.Name}{Environment.NewLine}{{".IndentLines(indentLevel++));

        builder.Append(Environment.NewLine);

        value.Fields
            .ForEach(f => builder.Append(_fieldGenerator.Generate(f)
                                             .IndentLines(indentLevel))
                              .Append(Environment.NewLine));

        builder.Append(Environment.NewLine
                           .Indent(indentLevel));

        value.Constructors
            .ForEach(c => builder.Append(_constrcutorGenerator.Generate(c)
                                             .IndentLines(indentLevel))
                              .Append(Environment.NewLine));

        builder.Append(Environment.NewLine
                           .Indent(indentLevel));

        value.Methods
            .ForEach(m => builder.Append(_methodGenerator.Generate(m)
                                             .IndentLines(indentLevel))
                              .Append(Environment.NewLine));

        builder.Append("}".Indent(--indentLevel))
            .Append(Environment.NewLine)
            .Append("}".Indent(--indentLevel))
            .Append(Environment.NewLine);

        return builder.ToString();
    }
}
