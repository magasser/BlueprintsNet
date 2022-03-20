namespace BlueprintsNet.Generator.Tests.Extensions;

[TestFixture(TestOf = typeof(StringExtensions))]
public class StringExtensionsTests
{
    #region Validation
    [Test]
    public void Given_null_string_When_Indent_Then_throw_exception()
    {
        // Act
        var nullStringCall = () => StringExtensions.Indent(null, 0);

        // Assert
        nullStringCall.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("source");
    }

    [Test]
    public void Given_null_string_When_IndentLines_Then_throw_exception()
    {
        // Act
        var nullStringCall = () => StringExtensions.IndentLines(null, 0);

        // Assert
        nullStringCall.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("source");
    }
    #endregion Validation

    [TestCase("", 0, ExpectedResult = "")]
    [TestCase("", 1, ExpectedResult = "\t")]
    [TestCase("indent", 2, ExpectedResult = "\t\tindent")]
    [TestCase("  indent", 3, ExpectedResult = "\t\t\t  indent")]
    public string When_Indent_Then_return_indented_string(string subject, int indentLevel)
    {
        // Act - Assert
        return subject.Indent(indentLevel);
    }

    [TestCase("\n", 0, ExpectedResult = "\n")]
    [TestCase("\n", 1, ExpectedResult = "\t\r\n\t")]
    [TestCase("\r\n", 1, ExpectedResult = "\t\r\n\t")]
    [TestCase("\r", 1, ExpectedResult = "\t\r\n\t")]
    [TestCase("before\nafter", 2, ExpectedResult = "\t\tbefore\r\n\t\tafter")]
    [TestCase("before\r\nmiddle\r\nafter", 3, ExpectedResult = "\t\t\tbefore\r\n\t\t\tmiddle\r\n\t\t\tafter")]
    public string When_IndentLines_Then_return_indented_lines(string subject, int indentLevel)
    {
        // Act - Assert
        return subject.IndentLines(indentLevel);
    }
}
