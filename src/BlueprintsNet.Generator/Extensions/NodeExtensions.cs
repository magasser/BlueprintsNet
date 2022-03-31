
namespace BlueprintsNet.Core.Models.Blueprints;

internal static class NodeExtensions
{
    public static string Evaluate(this IIn source, IBlueprintGenerator blueprintGenerator)
    {
        source.MustNotBeNull();
        blueprintGenerator.MustNotBeNull();

        if (source.Previous?.Parent is IEntryPoint)
        {
            return source.Previous.DisplayName;
        }

        return source.Previous?.Parent.Generate(blueprintGenerator) ?? source.ConstantValue;
    }

    public static string Evaluate(this Connection.Out source, IBlueprintGenerator blueprintGenerator)
    {
        source.MustNotBeNull();
        blueprintGenerator.MustNotBeNull();

        return source.HasNext
            ? source.Next!.Parent
                          .Generate(blueprintGenerator)
            : string.Empty;
    }
}
