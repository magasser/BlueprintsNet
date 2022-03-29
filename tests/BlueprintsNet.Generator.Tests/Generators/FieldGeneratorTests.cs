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

    [TestCase("fieldPrivate", NodeType.Bool, AccessModifier.Private, ExpectedResult = "private bool fieldPrivate;")]
    [TestCase("fieldProtected", NodeType.String, AccessModifier.Protected, ExpectedResult = "protected string fieldProtected;")]
    [TestCase("fieldInternal", NodeType.Integer, AccessModifier.Internal, ExpectedResult = "internal int fieldInternal;")]
    public string Given_Field_When_Generate_Then_return_correct_field_string(string name,
                                                                             NodeType nodeType,
                                                                             AccessModifier accessModifier)
    {
        return _subject.Generate(new Field(name, accessModifier, nodeType));
    }

    [TestCase("fieldPrivate", "Test", AccessModifier.Private, ExpectedResult = "private Test fieldPrivate;")]
    [TestCase("fieldProtected", "Person", AccessModifier.Protected, ExpectedResult = "protected Person fieldProtected;")]
    [TestCase("fieldInternal", "IInterface", AccessModifier.Internal, ExpectedResult = "internal IInterface fieldInternal;")]
    public string Give_ObjectField_When_Generate_Then_return_correct_field_string(string name,
                                                                                  string objectType,
                                                                                  AccessModifier accessModifier)
    {
        return _subject.Generate(new ObjectField(name, accessModifier, objectType));
    }
}
