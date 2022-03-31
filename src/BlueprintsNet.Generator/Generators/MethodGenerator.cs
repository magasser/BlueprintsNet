
namespace BlueprintsNet.Generator.Generators;

internal class MethodGenerator : IGenerator<Method>
{
    private readonly IBlueprintGenerator _bpGenerator;

    public MethodGenerator(IBlueprintGenerator bpGenerator)
    {
        _bpGenerator = bpGenerator.MustNotBeNull();
    }

    public string Generate(Method value)
    {
        return _bpGenerator.Generate(value.Start);
    }
}
