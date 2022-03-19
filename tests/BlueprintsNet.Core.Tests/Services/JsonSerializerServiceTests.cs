using Newtonsoft.Json;
using BlueprintsNet.Core.Services;

namespace BlueprintsNet.Core.Tests.Services;

[TestFixture(TestOf = typeof(JsonSerializerService))]
public class JsonSerializerServiceTests
{
    private ILogger<JsonSerializerService> _logger;
    private List<JsonConverter> _jsonConverters;
    private JsonSerializerService _subject;

    [SetUp]
    public void SetUp()
    {
        _logger = NullLogger<JsonSerializerService>.Instance;
        _jsonConverters = new List<JsonConverter>();

        _subject = new JsonSerializerService(_logger, _jsonConverters);
    }

    #region Validation
    [Test]
    public void Given_invalid_arguments_When_constructed_Then_throw_exception()
    {
        // Act
        var nullLoggerCall = () => new JsonSerializerService(logger: null!, _jsonConverters);
        var nullJsonConvertersCall = () => new JsonSerializerService(_logger, jsonConverters: null!);

        // Assert
        using (new AssertionScope())
        {
            nullLoggerCall.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithParameterName("logger");
            nullJsonConvertersCall.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithParameterName("jsonConverters");
        }
    }

    [Test]
    public void Given_null_value_When_Serialize_Then_throw_exception()
    {
        // Act
        var nullValueCall = () => _subject.Serialize<TestObject>(null!);

        // Assert
        nullValueCall.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("value");
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void Given_invalid_value_When_Deserialize_Then_throw_exception(string invalidValue)
    {
        // Act
        var invalidValueCall = () => _subject.Deserialize<TestObject>(invalidValue);

        // Assert
        invalidValueCall.Should()
            .Throw<ArgumentException>()
            .WithParameterName("value");
    }
    #endregion Validation

    [Test]
    public void When_Serialize_Then_return_correct_json_string()
    {
        // Arrange
        var testObject = new TestObject { TestBool = true, TestInt = 3, TestString = "string" };
        const string expected = "{\r\n  \"TestBool\": true,\r\n  \"TestInt\": 3,\r\n  \"TestString\": \"string\"\r\n}";

        // Act
        var result = _subject.Serialize(testObject);

        // Assert
        result.Should()
            .Be(expected);
    }

    [Test]
    public void When_Deserialize_Then_return_correct_object()
    {
        // Arrange
        const string jsonString = "{\r\n  \"TestBool\": true,\r\n  \"TestInt\": 3,\r\n  \"TestString\": \"string\"\r\n}";
        var expected = new TestObject { TestBool = true, TestInt = 3, TestString = "string" };

        // Act
        var result = _subject.Deserialize<TestObject>(jsonString);

        // Assert
        result.Should()
            .BeEquivalentTo(expected);
    }

    public class TestObject
    {
        public bool TestBool { get; init; }

        public int TestInt { get; init; }

        public string TestString { get; init; }
    }
}
