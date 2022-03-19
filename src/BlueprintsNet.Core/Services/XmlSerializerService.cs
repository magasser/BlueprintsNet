using System.Xml;
using System.Text;
using System.Xml.Serialization;

namespace BlueprintsNet.Core.Services;

internal class XmlSerializerService : ISerializerService
{
    private const string DefaultNamespace = "http://www.w3.org/2001/XMLSchema";
    private static readonly XmlSerializerNamespaces _xmlSerializerNamespaces =
        new XmlSerializerNamespaces(new XmlQualifiedName[]
        {
            new("xs", "http://www.w3.org/2001/XMLSchema"),
            new("xsi", "http://www.w3.org/2001/XMLSchema-instance")
        });

    private readonly ILogger<XmlSerializerService> _logger;

    public XmlSerializerService(ILogger<XmlSerializerService> logger)
    {
        _logger = logger.MustNotBeNull();
    }

    public string Serialize<T>(T value)
    {
        value.MustNotBeNullReference();

        _logger.LogTrace("Try to serialize value: {Value}.", value);

        var serializer = new XmlSerializer(typeof(T));

        using var memoryStream = new MemoryStream();
        using var xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        xmlWriter.Namespaces = true;

        serializer.Serialize(xmlWriter, value);

        var result = Encoding.UTF8
                         .GetString(memoryStream.ToArray());

        _logger.LogDebug("Serialized value: {Result}", result);

        return result;
    }

    public T Deserialize<T>(string value)
    {
        value.MustNotBeNullOrWhiteSpace();

        _logger.LogTrace("Try to deserialize xml string: {Value}.", value);

        var serializer = new XmlSerializer(typeof(T));

        using var stringReader = new StringReader(value);
        using var xmlReader = new XmlTextReader(stringReader);

        var obj = serializer.Deserialize(xmlReader) ??
            throw new InvalidOperationException($"Failed to deserialize xml string: {value}.");

        var result = (T)obj;

        _logger.LogDebug("Deserialized value: {Result}.", result);

        return result;
    }
}
