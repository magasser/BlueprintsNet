
namespace System;

internal static class StringExtensions
{
    public static string IndentLines(this string source,
                                     int indentLevel,
                                     string indentFormat = "    ")
    {
        source.MustNotBeNull();

        if (indentLevel <= 0)
        {
            return source;
        }

        var lines = source.Split(new string[] { Environment.NewLine, "\r\n", "\n", "\r" }, StringSplitOptions.None);

        var indentedLines = lines.Select(line => line.Indent(indentLevel, indentFormat));


        return string.Join(Environment.NewLine, indentedLines);
    }

    public static string Indent(this string source,
                                int indentLevel,
                                string indentFormat = "    ")
    {
        source.MustNotBeNull();

        return indentLevel > 0 ? $"{indentFormat}{source.Indent(indentLevel - 1)}" : source;
    }
}
