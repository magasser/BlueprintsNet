using BlueprintsNet.Core.Domain;
using BlueprintsNet.Core.Services;
using BlueprintsNet.Generator.Services;
using BlueprintsNet.Core.Models.Classes;
using BlueprintsNet.Generator.Generators;

namespace BlueprintsNet.Generator.Tests.Services;

[TestFixture(TestOf = typeof(GeneratorService))]
public class GeneratorServiceTests
{
    private ILogger<GeneratorService> _logger;
    private IGenerator<Class> _classGenerator;
    private IFileService _fileService;

    private GeneratorService _subject;

    [SetUp]
    public void SetUp()
    {
        _logger = NullLogger<GeneratorService>.Instance;
        _classGenerator = A.Fake<IGenerator<Class>>(options => options.Strict());
        _fileService = A.Fake<IFileService>(options => options.Strict());

        _subject = new GeneratorService(_logger, _classGenerator, _fileService);
    }

    #region Validation
    [Test]
    public void Given_invalid_arguments_When_constructed_Then_throw_exception()
    {
        // Act
        var nullLoggerCall = () => new GeneratorService(logger: null, _classGenerator, _fileService);
        var nullClassGeneratorCall = () => new GeneratorService(_logger, classGenerator: null, _fileService);
        var nullFileServiceCall = () => new GeneratorService(_logger, _classGenerator, fileService: null);

        // Assert
        using (new AssertionScope())
        {
            nullLoggerCall.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithParameterName("logger");
            nullClassGeneratorCall.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithParameterName("classGenerator");
            nullFileServiceCall.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithParameterName("fileService");
        }
    }

    [Test]
    public void Given_invalid_arguments_When_GenerateClass_Then_throw_exception()
    {
        // Act
        var nullClassCall = () => _subject.GenerateClass(null);

        // Assert
        nullClassCall.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("@class");
    }
    #endregion Validation

    [Test]
    public void When_GenerateClass_Then_call_correct_services()
    {
        // Arrange
        var @class = new Class("Test",
                               "TestClasses.Tests",
                               "Tests",
                               AccessModifier.Public);

        A.CallTo(() => _classGenerator.Generate(@class))
            .Returns("GeneratedClass");

        var writeCall = A.CallTo(() => _fileService.Write($"{Folders.Output}\\Tests\\Test.cs", "GeneratedClass"));
        writeCall.DoesNothing();

        // Act
        _subject.GenerateClass(@class);

        // Assert
        writeCall.MustHaveHappenedOnceExactly();
    }
}
