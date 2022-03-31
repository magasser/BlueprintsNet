
namespace System.Text;

internal static class StringBuilderExtensions
{
    public static StringBuilder NewLine(this StringBuilder stringBuilder)
    {
        stringBuilder.MustNotBeNull();

        return stringBuilder.Append(Environment.NewLine);
    }
}
