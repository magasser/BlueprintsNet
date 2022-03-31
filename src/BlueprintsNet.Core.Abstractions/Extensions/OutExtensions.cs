
namespace BlueprintsNet.Core.Models.Blueprints;

public static class OutExtensions
{
    public static IIn ToIn(this IOut source)
    {
        source.MustNotBeNull();

        return source.DataType
                     .ToIn(source.Parent, source.DisplayName);
    }
}
