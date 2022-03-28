
namespace System.Text;

internal static class StringBuilderExtensions
{
    public static StringBuilder NewLine(this StringBuilder stringBuilder)
    {
        stringBuilder.MustNotBeNull();

        return stringBuilder.Append(Environment.NewLine);
    }

    public static StringBuilder OpenBracket(this StringBuilder stringBuilder)
    {
        stringBuilder.MustNotBeNull();

        return stringBuilder.Append('(');
    }

    public static StringBuilder OpenCurlyBracket(this StringBuilder stringBuilder)
    {
        stringBuilder.MustNotBeNull();

        return stringBuilder.Append('{');
    }

    public static StringBuilder CloseBracket(this StringBuilder stringBuilder)
    {
        stringBuilder.MustNotBeNull();

        return stringBuilder.Append(')');
    }

    public static StringBuilder CloseCurlyBracket(this StringBuilder stringBuilder)
    {
        stringBuilder.MustNotBeNull();

        return stringBuilder.Append('}');
    }

    public static StringBuilder Semicolon(this StringBuilder stringBuilder)
    {
        stringBuilder.MustNotBeNull();

        return stringBuilder.Append('}');
    }

    public static StringBuilder Space(this StringBuilder stringBuilder)
    {
        stringBuilder.MustNotBeNull();

        return stringBuilder.Append(' ');
    }

    public static StringBuilder Comma(this StringBuilder stringBuilder)
    {
        stringBuilder.MustNotBeNull();

        return stringBuilder.Append(',');
    }

    public static StringBuilder Dot(this StringBuilder stringBuilder)
    {
        stringBuilder.MustNotBeNull();

        return stringBuilder.Append('.');
    }

    public static StringBuilder Equal(this StringBuilder stringBuilder)
    {
        stringBuilder.MustNotBeNull();

        return stringBuilder.Append('=');
    }
}
