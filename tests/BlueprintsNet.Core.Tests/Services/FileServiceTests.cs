using BlueprintsNet.Core.Services;

namespace BlueprintsNet.Core.Tests.Services;

[TestFixture(TestOf = typeof(FileService))]
public class FileServiceTests
{
    private const string DirectoryPath = "FileServiceTests";
    private const string FileName = "FileService.txt";
    private const string FilePath = $"{DirectoryPath}\\{FileName}";

    private ILogger<FileService> _logger;
    private FileService _subject;

    [SetUp]
    public void SetUp()
    {
        _logger = NullLogger<FileService>.Instance;

        _subject = new FileService(_logger);

        Directory.CreateDirectory(DirectoryPath);
    }

    [TearDown]
    public void TearDown()
    {
        Directory.Delete(DirectoryPath, true);
    }

    #region Validation
    [Test]
    public void Given_invalid_arguments_When_constructed_Then_throw_exception()
    {
        // Act
        var nullLoggerCall = () => new XmlSerializerService(logger: null!);

        // Assert
        nullLoggerCall.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("logger");
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void Given_invalid_path_When_Read_Then_throw_exception(string invalidPath)
    {
        // Act
        var invalidPathCall = () => _subject.Read(invalidPath);

        // Assert
        invalidPathCall.Should()
            .Throw<ArgumentException>()
            .WithParameterName("path");
    }

    [TestCase(null, "valid", "path")]
    [TestCase("", "valid", "path")]
    [TestCase("   ", "valid", "path")]
    [TestCase("valid", null, "content")]
    [TestCase("valid", "", "content")]
    [TestCase("valid", "   ", "content")]
    public void Given_invalid_arguments_When_Write_Then_throw_exception(string path,
                                                                        string content,
                                                                        string parameterName)
    {
        // Act
        var invalidArgumentsCall = () => _subject.Write(path, content);

        // Assert
        invalidArgumentsCall.Should()
            .Throw<ArgumentException>()
            .WithParameterName(parameterName);
    }
    #endregion Validation

    [Test]
    public void When_Read_Then_return_correct_string()
    {
        // Arrange
        const string expected = "Some text";

        File.WriteAllText(FilePath, expected);

        // Act
        var result = _subject.Read(FilePath);

        // Assert
        result.Should()
            .Be(expected);
    }

    [Test]
    public void When_Write_Then_write_content_to_file()
    {
        // Arrange
        const string writeText = "Some text";

        // Act
        _subject.Write(FilePath, writeText);

        // Assert
        var result = File.ReadAllText(FilePath);

        result.Should()
            .Be(writeText);
    }
}
