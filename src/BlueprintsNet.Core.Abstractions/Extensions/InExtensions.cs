
namespace BlueprintsNet.Core.Models.Blueprints;

public static class InExtensions
{
    public static IOut ToOut(this IIn source)
    {
        source.MustNotBeNull();

        return source.DataType
                     .ToOut(source.Parent, source.DisplayName);
    }
}
