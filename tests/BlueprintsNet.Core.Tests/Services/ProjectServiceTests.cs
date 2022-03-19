using BlueprintsNet.Core.Services;
using BlueprintsNet.Core.Models.Code;
using BlueprintsNet.Core.Models.Files;

namespace BlueprintsNet.Core.Tests.Services;

[TestFixture(TestOf = typeof(ProjectService))]
public class ProjectServiceTests
{
    private ILogger<ProjectService> _logger;
    private ISerializerService _serializerService;
    private IFileService _fileService;
    private ProjectService _subject;

    [SetUp]
    public void SetUp()
    {
        _logger = NullLogger<ProjectService>.Instance;
        _serializerService = A.Fake<ISerializerService>(options => options.Strict());
        _fileService = A.Fake<IFileService>(options => options.Strict());

        _subject = new ProjectService(_logger, _serializerService, _fileService);
    }

    #region Validation
    [Test]
    public void Given_invalid_arguments_When_constructed_Then_throw_exception()
    {
        // Act
        var nullLoggerCall = () => new ProjectService(logger: null!, _serializerService, _fileService);
        var nullSerializerServiceCall = () => new ProjectService(_logger, serializerService: null!, _fileService);
        var nullFileServiceCall = () => new ProjectService(_logger, _serializerService, fileService: null!);

        // Assert
        using (new AssertionScope())
        {
            nullLoggerCall.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithParameterName("logger");
            nullSerializerServiceCall.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithParameterName("serializerService");
            nullFileServiceCall.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithParameterName("fileService");
        }
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void Given_invalid_path_When_LoadClass_Then_throw_exception(string invalidPath)
    {
        // Act
        var invalidPathCall = () => _subject.LoadClass(invalidPath);

        // Assert
        invalidPathCall.Should()
            .Throw<ArgumentException>()
            .WithParameterName("path");
    }

    [Test]
    public void Given_null_class_When_SaveClass_Then_throw_exception()
    {
        // Act
        var nullClassCall = () => _subject.SaveClass(null);

        nullClassCall.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("@class");
    }
    #endregion Validation

    [Test]
    public void When_LoadClass_Then_call_services_with_correct_arguments()
    {
        // Arrange
        const string path = "file/path";
        const string content = "file content";
        var classFile = new ClassFile(
            new ClassFileInfo(), 
            new Class("Test", path, AccessModifier.Public));

        var readCall = A.CallTo(() => _fileService.Read(path));
        readCall.Returns(content);

        A.CallTo(() => _serializerService.Deserialize<ClassFile>(content))
            .Returns(classFile);

        // Act
        _subject.LoadClass(path);

        // Assert
        readCall.MustHaveHappenedOnceExactly();
    }

    [Test]
    public void When_SaveClass_Then_call_services_with_correct_arguments()
    {
        // Arrange
        const string path = "file/path";
        const string content = "file content";
        var @class = new Class("Test", "file/path", AccessModifier.Public);
        var classFile = new ClassFile(new ClassFileInfo(), @class);

        A.CallTo(() => _serializerService.Serialize(classFile))
            .Returns(content);

        var writeCall = A.CallTo(() => _fileService.Write(path, content));
        writeCall.DoesNothing();

        // Act
        _subject.SaveClass(@class);

        // Assert
        writeCall.MustHaveHappenedOnceExactly();
    }
}
