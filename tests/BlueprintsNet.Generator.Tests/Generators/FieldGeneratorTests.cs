using BlueprintsNet.Core.Domain;
using BlueprintsNet.Core.Models.Classes;
using BlueprintsNet.Generator.Generators;

namespace BlueprintsNet.Generator.Tests.Generators;

[TestFixture(TestOf = typeof(FieldGenerator))]
public class FieldGeneratorTests
{
    private FieldGenerator _subject;

    [SetUp]
    public void SetUp()
    {
        _subject = new FieldGenerator();
    }

    #region Validation
    [Test]
    public void Given_invalid_arguments_When_Generate_Then_throw_exception()
    {
        // Act
        var nullFieldCall = () => _subject.Generate(null);

        // Assert
        nullFieldCall.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("value");
    }
    #endregion Validation

    [TestCase("fieldPrivate", "bool", AccessModifier.Private, ExpectedResult = "private bool fieldPrivate;")]
    [TestCase("fieldProtected", "string", AccessModifier.Protected, ExpectedResult = "protected string fieldProtected;")]
    [TestCase("fieldInternal", "int", AccessModifier.Internal, ExpectedResult = "internal int fieldInternal;")]
    [TestCase("fieldPublic", "Test", AccessModifier.Public, ExpectedResult = "public Test fieldPublic;")]
    public string When_Generate_Then_return_correct_field_string(string name,
                                                                 string type,
                                                                 AccessModifier accessModifier)
    {
        return _subject.Generate(new Field(name, accessModifier, type));
    }
}
