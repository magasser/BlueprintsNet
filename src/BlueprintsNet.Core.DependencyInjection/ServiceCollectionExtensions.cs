using Light.GuardClauses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using BlueprintsNet.Core.Domain;
using BlueprintsNet.Core.Services;
using BlueprintsNet.Core.JsonConverters;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlueprintsNetCore(this IServiceCollection services, SerializerType serializerType)
    {
        services.MustNotBeNull();

        services.AddSingleton<IProjectService, ProjectService>()
            .AddSingleton<IFileService, FileService>();

        return serializerType switch
        {
            SerializerType.Xml => services.AddSingleton<ISerializerService, XmlSerializerService>(),
            SerializerType.Json => services.AddSingleton<ISerializerService, JsonSerializerService>()
                                       .AddSingleton(new List<JsonConverter>
                                       {
                                           new TypeJsonConverter(),
                                           new StringEnumConverter()
                                       }),
            _ => throw new NotSupportedException($"The serializer type {serializerType} is not supported.")
        };
    }
}
