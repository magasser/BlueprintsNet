
namespace System.Text;

internal static class StringBuilderExtensions
{
    public static StringBuilder NewLine(this StringBuilder stringBuilder)
    {
        stringBuilder.MustNotBeNull();

        stringBuilder.Append(Environment.NewLine);

        return stringBuilder;
    }
}
