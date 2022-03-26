using BlueprintsNet.Core;
using BlueprintsNet.Core.Models.Blueprints;

namespace BlueprintsNet.Generator.Generators;

internal abstract class BlueprintGeneratorBase : IBlueprintGenerator
{
    public abstract string Generate(BPSet bp);

    public abstract string Generate(BPIf bp);

    public abstract string Generate(BPField bp);

    public abstract string Generate(BPPlus bp);

    public abstract string Generate(BPMethod bp);

    public abstract string Generate(BPMethodIn bp);

    public abstract string Generate(BPLogicalAnd bp);

    public abstract string Generate(BPConstructorIn bp);

    public abstract string Generate(BPConstructor bp);

    public abstract string Generate(BPFor bp);

    public abstract string Generate(BPReturn bp);
}
