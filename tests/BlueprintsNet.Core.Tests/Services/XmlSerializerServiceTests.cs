using BlueprintsNet.Core.Services;

namespace BlueprintsNet.Core.Tests.Services;

[Ignore("Class not used")]
[TestFixture(TestOf = typeof(XmlSerializerService))]
public class XmlSerializerServiceTests
{
    private ILogger<XmlSerializerService> _logger;
    private XmlSerializerService _subject;

    [SetUp]
    public void SetUp()
    {
        _logger = NullLogger<XmlSerializerService>.Instance;

        _subject = new XmlSerializerService(_logger);
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
    public void When_Serialize_Then_return_correct_xml_string()
    {
        // Arrange
        var testObject = new TestObject("test");
        const string expected = "﻿<?xml version=\"1.0\" encoding=\"utf-8\"?><xs:TestObject xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" />";

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
        const string xmlString = @"﻿<?xml version=""1.0"" encoding=""utf-8""?>
                        <xs:TestObject xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
                            <TestValue>test</TestValue>
                        </xs:TestObject>";

        // Act
        var result = _subject.Deserialize<TestObject>(xmlString);

        // Assert
        result.Should()
            .NotBeNull();
        result.Should()
            .BeOfType<TestObject>();
        result.TestValue
            .Should()
            .Be("test");
    }

    public class TestObject
    {
        public TestObject() { }

        public TestObject(string value)
        {
            TestValue = value;
        }

        public string TestValue { get; }
    }
}
