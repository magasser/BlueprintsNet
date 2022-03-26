using System;
using System.Linq;

namespace BlueprintsNet.Generator.Generators;

internal class ConstructorGenerator : IGenerator<Constructor>
{
    private readonly IBlueprintGenerator _bpGenerator;

    public ConstructorGenerator(IBlueprintGenerator bpGenerator)
    {
        _bpGenerator = bpGenerator.MustNotBeNull();
    }

    public string Generate(Constructor value)
    {
        return _bpGenerator.Generate(value.Start);
    }
}
