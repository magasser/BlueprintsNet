using BlueprintsNet.Core.Files;
using BlueprintsNet.Core.Domain;
using BlueprintsNet.Core.Services;
using BlueprintsNet.Core.Models.Classes;
using BlueprintsNet.Core.Models.Projects;

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

    [TestCase(null, "valid", "name")]
    [TestCase("", "valid", "name")]
    [TestCase("   ", "valid", "name")]
    [TestCase("valid", null, "folderPath")]
    [TestCase("valid", "", "folderPath")]
    [TestCase("valid", "   ", "folderPath")]
    public void Given_invalid_arguments_When_LoadClass_Then_throw_exception(string name,
                                                                            string invalidPath,
                                                                            string parameterName)
    {
        // Act
        var invalidPathCall = () => _subject.LoadClass(name, invalidPath);

        // Assert
        invalidPathCall.Should()
            .Throw<ArgumentException>()
            .WithParameterName(parameterName);
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

    [TestCase(null, "valid", "name")]
    [TestCase("", "valid", "name")]
    [TestCase("   ", "valid", "name")]
    [TestCase("valid", null, "folderPath")]
    [TestCase("valid", "", "folderPath")]
    [TestCase("valid", "   ", "folderPath")]
    public void Given_invalid_arguments_When_LoadProject_Then_throw_exception(string name,
                                                                              string invalidPath,
                                                                              string parameterName)
    {
        // Act
        var invalidPathCall = () => _subject.LoadProject(name, invalidPath);

        // Assert
        invalidPathCall.Should()
            .Throw<ArgumentException>()
            .WithParameterName(parameterName);
    }

    [Test]
    public void Given_null_class_When_SaveProject_Then_throw_exception()
    {
        // Act
        var nullClassCall = () => _subject.SaveProject(null);

        nullClassCall.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("project");
    }
    #endregion Validation

    [Test]
    public void When_LoadClass_Then_call_services_with_correct_arguments()
    {
        // Arrange
        const string path = "file\\path";
        const string content = "file content";
        var classFile = new ClassFile(
            new ClassFileInfo(), 
            new Class("Test", path, AccessModifier.Public));

        var readCall = A.CallTo(() => _fileService.Read($"{path}\\Test.{classFile.ClassFileInfo.Extension}"));
        readCall.Returns(content);

        A.CallTo(() => _serializerService.Deserialize<ClassFile>(content))
            .Returns(classFile);

        // Act
        _subject.LoadClass("Test", path);

        // Assert
        readCall.MustHaveHappenedOnceExactly();
    }

    [Test]
    public void When_SaveClass_Then_call_services_with_correct_arguments()
    {
        // Arrange
        const string path = "file\\path";
        const string content = "file content";
        var @class = new Class("Test", "file\\path", AccessModifier.Public);
        var classFile = new ClassFile(new ClassFileInfo(), @class);

        A.CallTo(() => _serializerService.Serialize(classFile))
            .Returns(content);

        var writeCall = A.CallTo(() => _fileService.Write($"{path}\\Test.{classFile.ClassFileInfo.Extension}", content));
        writeCall.DoesNothing();

        // Act
        _subject.SaveClass(@class);

        // Assert
        writeCall.MustHaveHappenedOnceExactly();
    }

    [Test]
    public void When_LoadProject_Then_call_services_with_correct_arguments()
    {
        // Arrange
        const string path = "file\\path";
        const string content = "file content";
        var projectFile = new ProjectFile(
            new ProjectFileInfo(),
            new Project(new Guid("4BA267AD-5341-4085-8E7F-3C1EA2CFD2A7"),
                        "Test",
                        path,
                        Array.Empty<Class>()));

        var readCall = A.CallTo(() => _fileService.Read($"{path}\\Test.{projectFile.ProjectFileInfo.Extension}"));
        readCall.Returns(content);

        A.CallTo(() => _serializerService.Deserialize<ProjectFile>(content))
            .Returns(projectFile);

        // Act
        _subject.LoadProject("Test", path);

        // Assert
        readCall.MustHaveHappenedOnceExactly();
    }

    [Test]
    public void When_SaveProject_Then_call_services_with_correct_arguments()
    {
        // Arrange
        const string path = "file\\path";
        const string content = "file content";
        var project = new Project(new Guid("4BA267AD-5341-4085-8E7F-3C1EA2CFD2A7"),
                                  "Test",
                                  path,
                                  Array.Empty<Class>());
        var projectFile = new ProjectFile(
            new ProjectFileInfo(),
            project);

        A.CallTo(() => _serializerService.Serialize(projectFile))
            .Returns(content);

        var writeCall = A.CallTo(() => _fileService.Write($"{path}\\Test.{projectFile.ProjectFileInfo.Extension}", content));
        writeCall.DoesNothing();

        // Act
        _subject.SaveProject(project);

        // Assert
        writeCall.MustHaveHappenedOnceExactly();
    }
}
