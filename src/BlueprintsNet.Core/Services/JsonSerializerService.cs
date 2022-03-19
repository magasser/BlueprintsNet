using Newtonsoft.Json;

namespace BlueprintsNet.Core.Services;

internal class JsonSerializerService : ISerializerService
{
    public readonly ILogger<JsonSerializerService> _logger;
    public readonly JsonSerializerSettings _serializerSettings;

    public JsonSerializerService(ILogger<JsonSerializerService> logger, List<JsonConverter> jsonConverters)
    {
        _logger = logger.MustNotBeNull();

        jsonConverters.MustNotBeNull();

        _serializerSettings = new JsonSerializerSettings
        {
            Converters = jsonConverters,
            Formatting = Formatting.Indented,
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            TypeNameHandling = TypeNameHandling.Auto
        };
    }

    public string Serialize<T>(T value)
    {
        value.MustNotBeNullReference();

        _logger.LogTrace("Try to serialize value: {Value}.", value);

        var result = JsonConvert.SerializeObject(value, _serializerSettings);

        _logger.LogDebug("Serialized value: {Result}.", result);

        return result;
    }

    public T Deserialize<T>(string value)
    {
        value.MustNotBeNullOrWhiteSpace();

        _logger.LogTrace("Try to deserialize json string: {Value}.", value);

        var result = JsonConvert.DeserializeObject<T>(value, _serializerSettings) ??
            throw new InvalidOperationException($"Failed to deserialize json string '{value}'.");

        _logger.LogDebug("Deserialized value: {Result}.", result);

        return result;
    }
}
