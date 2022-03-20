using System;
using System.Linq;
using BlueprintsNet.Core.Domain;
using BlueprintsNet.Core.Models.Classes;
using BlueprintsNet.Generator.Generators;

namespace BlueprintsNet.Generator.Tests.Generators;

[TestFixture(TestOf = typeof(ClassGenerator))]
public class ClassGeneratorTests
{
    private ILogger<ClassGenerator> _logger;
    private IGenerator<Constructor> _constructorGenerator;
    private IGenerator<Field> _fieldGenerator;
    private IGenerator<Method> _methodGenerator;

    private ClassGenerator _subject;

    [SetUp]
    public void SetUp()
    {
        _logger = NullLogger<ClassGenerator>.Instance;
        _constructorGenerator = A.Fake<IGenerator<Constructor>>(options => options.Strict());
        _fieldGenerator = A.Fake<IGenerator<Field>>(options => options.Strict());
        _methodGenerator = A.Fake<IGenerator<Method>>(options => options.Strict());

        _subject = new ClassGenerator(_logger,
                                      _constructorGenerator,
                                      _fieldGenerator,
                                      _methodGenerator);
    }

    #region Validation
    [Test]
    public void Given_invalid_arguments_When_constructed_Then_throw_exception()
    {
        // Act
        var nullLoggerCall = () => new ClassGenerator(logger: null,
                                                      _constructorGenerator,
                                                      _fieldGenerator,
                                                      _methodGenerator);
        var nullConstructorGeneratorCall = () => new ClassGenerator(_logger,
                                                                    constructorGenerator: null,
                                                                    _fieldGenerator,
                                                                    _methodGenerator);
        var nullFieldGeneratorCall = () => new ClassGenerator(_logger,
                                                              _constructorGenerator,
                                                              fieldGenerator: null,
                                                              _methodGenerator);
        var nullMethodGeneratorCall = () => new ClassGenerator(_logger,
                                                               _constructorGenerator,
                                                               _fieldGenerator,
                                                               methodGenerator: null);

        // Assert
        using (new AssertionScope())
        {
            nullLoggerCall.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithParameterName("logger");
            nullConstructorGeneratorCall.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithParameterName("constructorGenerator");
            nullFieldGeneratorCall.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithParameterName("fieldGenerator");
            nullMethodGeneratorCall.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithParameterName("methodGenerator");
        }
    }

    [Test]
    public void Given_invalid_arguments_When_Generate_Then_throw_exception()
    {
        // Act
        var nullClassCall = () => _subject.Generate(null);

        // Assert
        nullClassCall.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("value");
    }
    #endregion Validation

    [TestCase("TestPrivate", "TestClasses.Tests", "Tests", AccessModifier.Private)]
    [TestCase("TestProtected", "TestClasses.Tests", "Tests", AccessModifier.Protected)]
    [TestCase("TestInternal", "TestClasses.Tests", "Tests", AccessModifier.Internal)]
    [TestCase("TestPublic", "TestClasses.Tests", "Tests", AccessModifier.Public)]
    public void When_Generate_Then_return_correct_class_string(string name,
                                                               string @namespace,
                                                               string folderPath,
                                                               AccessModifier accessModifier)
    {
        // Arrange
        var @class = new Class(name,
                               @namespace,
                               folderPath,
                               accessModifier);
        @class.Usings
            .AddRange(new string[] { "System", "System.Linq" });
        @class.Fields
            .AddRange(new Field[]
            {
                new Field("field1", AccessModifier.Private, "bool"),
                new Field("field2", AccessModifier.Private, "string")
            });
        @class.Constructors
            .Add(new Constructor(name, AccessModifier.Public));
        @class.Methods
            .AddRange(new Method[]
            {
                new Method("Method1", AccessModifier.Public),
                new Method("Method2", AccessModifier.Public),
                new Method("Method3", AccessModifier.Public)
            });

        A.CallTo(() => _fieldGenerator.Generate(A<Field>._))
            .Returns($"GeneratedField;");
        A.CallTo(() => _constructorGenerator.Generate(A<Constructor>._))
            .Returns($"GeneratedConstructor");
        A.CallTo(() => _methodGenerator.Generate(A<Method>._))
            .Returns($"GeneratedMethod");

        var expected =
$@"using System;
using System.Linq;

namespace TestClasses.Tests
{{
    {accessModifier.ToString().ToLower()} class {name}
    {{
        GeneratedField;
        GeneratedField;
        
        GeneratedConstructor
        
        GeneratedMethod
        GeneratedMethod
        GeneratedMethod
    }}
}}
";

        // Act
        var result = _subject.Generate(@class);

        // Assert
        result.Should()
            .Be(expected);
    }
}
